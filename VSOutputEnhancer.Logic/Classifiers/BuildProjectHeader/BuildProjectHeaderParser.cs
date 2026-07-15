using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildProjectHeader;

[Export(typeof(IParser<BuildProjectHeaderData>))]
public class BuildProjectHeaderParser : IParser<BuildProjectHeaderData>
{
    public bool TryParse(SnapshotSpan span, out BuildProjectHeaderData result)
    {
        result = null;
        var text = span.GetText();

        if (!text.EndsWith(" ------\r\n", StringComparison.Ordinal))
        {
            return false;
        }

        const string regex = "^(?:(?<BuildTaskId>\\d+)>)------ (?<FullMessage>.+) ------\r\n$";
        var match = Regex.Match(text, regex, RegexOptions.Compiled);
        if (!match.Success)
        {
            return false;
        }

        result = ParsedData.Create<BuildProjectHeaderData>(match, span.Span);
        return true;
    }
}
