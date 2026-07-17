using System.ComponentModel.Composition;
using Balakin.VSOutputEnhancer.Logic;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace Balakin.VSOutputEnhancer.UI.FormatDefinitions;

[Export(typeof(EditorFormatDefinition))]
[ClassificationType(ClassificationTypeNames = ClassificationType.DebugTraceWarning)]
[Name(ClassificationType.DebugTraceWarning)]
[UserVisible(false)]
[Order(Before = Priority.Default)]
[method: ImportingConstructor]
public sealed class DebugTraceWarningFormatDefinition(IStyleManager styleManager) : StyledClassificationFormatDefinition(styleManager)
{
}