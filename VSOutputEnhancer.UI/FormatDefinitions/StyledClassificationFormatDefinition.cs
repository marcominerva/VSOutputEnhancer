using System.Reflection;
using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.UI.FormatDefinitions;

public class StyledClassificationFormatDefinition : ClassificationFormatDefinition
{
    private string GetClassificationTypeName()
    {
        var type = GetType();
        var attribute = type.GetCustomAttribute<ClassificationTypeAttribute>();
        return attribute.ClassificationTypeNames;
    }

    private readonly Lazy<string> classificationTypeName;

    protected string ClassificationTypeName => classificationTypeName.Value;

    private StyledClassificationFormatDefinition()
    {
        classificationTypeName = new Lazy<string>(GetClassificationTypeName);

        var displayName = Resources.ResourceManager.GetString($"FormatDisplayName_{ClassificationTypeName}");
        DisplayName = displayName;
    }

    protected StyledClassificationFormatDefinition(IStyleManager styleManager) : this()
    {
        var style = styleManager.GetStyleForClassificationType(ClassificationTypeName);
        ForegroundColor = style.ForegroundColor;
        IsBold = style.Bold;
    }
}