using System.Collections.Concurrent;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.Logic;

[Export(typeof(IClassificationTypeService))]
[method: ImportingConstructor]
public class ClassificationTypeService(IClassificationTypeRegistryService classificationTypeRegistryService) : IClassificationTypeService
{
    private readonly IClassificationTypeRegistryService classificationTypeRegistryService = classificationTypeRegistryService;
    private readonly ConcurrentDictionary<string, IClassificationType> classificationTypes = new();

    public IClassificationType GetClassificationType(string name) => classificationTypes.GetOrAdd(name, classificationTypeRegistryService.GetClassificationType);
}