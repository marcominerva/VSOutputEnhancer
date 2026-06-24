using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Balakin.VSOutputEnhancer.UI.FormatDefinitions
{
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ClassificationType.BuildMessageError)]
    [Name(ClassificationType.BuildMessageError)]
    [UserVisible(false)]
    [Order(Before = Priority.Default)]
    [method: ImportingConstructor]
    public sealed class BuildMessageErrorFormatDefinition(IStyleManager styleManager) : StyledClassificationFormatDefinition(styleManager)
    {
    }
}