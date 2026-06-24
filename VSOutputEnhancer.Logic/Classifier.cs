using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.Logic
{
    public class Classifier(
        IDispatcher dispatcher,
        IReadOnlyCollection<ISpanClassifier> spanClassifiers,
        IClassificationTypeService classificationTypeService) : IClassifier
    {
        private readonly IDispatcher dispatcher = dispatcher;
        private readonly IReadOnlyCollection<ISpanClassifier> spanClassifiers = spanClassifiers;
        private readonly IClassificationTypeService classificationTypeService = classificationTypeService;

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var result = new List<ClassificationSpan>();
            foreach (var classifier in spanClassifiers)
            {
                var classifierResult = classifier.Classify(span, dispatcher);
                var classificationSpans = classifierResult.Select(r => CreateClassificationSpan(span, r));
                result.AddRange(classificationSpans);
            }

            return result;
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged
        {
            add { }
            remove { }
        }

        private ClassificationSpan CreateClassificationSpan(SnapshotSpan originalSpan, ProcessedParsedData data)
        {
            var classificationType = classificationTypeService.GetClassificationType(data.ClassificationName);
            var span = new SnapshotSpan(originalSpan.Snapshot, data.Span);
            return new ClassificationSpan(span, classificationType);
        }
    }
}