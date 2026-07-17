using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.Logic;

public interface IClassificationTypeService
{
    IClassificationType GetClassificationType(string name);
}