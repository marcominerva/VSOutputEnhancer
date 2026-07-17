using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Balakin.VSOutputEnhancer.Logic;

[Export(typeof(IClassifierProvider))]
[ContentType(ContentType.BuildOutput)]
[ContentType(ContentType.BuildOrderOutput)]
[ContentType(ContentType.DebugOutput)]
// For npm logs
[ContentType(ContentType.Output)]
#if DEBUG
[ContentType(ContentType.Text)]
#endif
[method: ImportingConstructor]
public class ClassifierProvider(
    IClassificationTypeService classificationTypeService,
    [ImportMany] IEnumerable<ISpanClassifier> spanClassifiers,
    [ImportMany] IEnumerable<IEventHandler> eventHandlers) : IClassifierProvider
{
    private readonly IClassificationTypeService classificationTypeService = classificationTypeService;
    private readonly IEnumerable<ISpanClassifier> spanClassifiers = spanClassifiers;
    private readonly IEnumerable<IEventHandler> eventHandlers = eventHandlers;

    public IClassifier GetClassifier(ITextBuffer textBuffer)
    {
        var contentType = textBuffer.ContentType;

        var classifiers = GetSpanClassifiers(contentType);
        if (!classifiers.Any())
        {
            return null;
        }

        var dispatcher = CreateDispatcher(contentType);
        var classifier = new Classifier(dispatcher, classifiers, classificationTypeService);
        return classifier;
    }

    private IReadOnlyCollection<ISpanClassifier> GetSpanClassifiers(IContentType contentType) => FilterByContentType(spanClassifiers, c => c.ContentTypes, contentType).ToArray();

    private Dispatcher CreateDispatcher(IContentType contentType)
    {
        var dispatcher = new Dispatcher();
        var handlers = FilterByContentType(eventHandlers, h => h.ContentTypes, contentType);
        foreach (var handler in handlers)
        {
            dispatcher.AddHandler(handler);
        }

        return dispatcher;
    }

    private IEnumerable<T> FilterByContentType<T>(
        IEnumerable<T> collection,
        Func<T, IEnumerable<string>> getContentTypes,
        IContentType contentType) => collection.Where(item => getContentTypes(item).Any(t => IsApplicable(contentType, t)));

    private bool IsApplicable(IContentType target, string contentType)
    {
        if (string.Equals(target.TypeName, contentType, StringComparison.Ordinal))
        {
            return true;
        }

        return target.BaseTypes.Any(baseType => IsApplicable(baseType, contentType));
    }
}