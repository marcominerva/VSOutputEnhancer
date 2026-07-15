using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Balakin.VSOutputEnhancer.UI.FormatDefinitions
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationType.BuildActionStartedSuccess)]
    [Name(ClassificationType.BuildActionStartedSuccess)]
    [UserVisible(false)]
    [Order(Before = Priority.Default)]
    [method: ImportingConstructor]
    public sealed class BuildActionStartedSuccessFormatDefinition(IStyleManager styleManager) : StyledClassificationFormatDefinition(styleManager)
    {
    }
}
