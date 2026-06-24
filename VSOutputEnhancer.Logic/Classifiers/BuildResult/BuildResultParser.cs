using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;

[Export(typeof(IParser<BuildResultData>))]
public class BuildResultParser : IParser<BuildResultData>
{
    public bool TryParse(SnapshotSpan span, out BuildResultData result)
    {
        result = null;
        var text = span.GetText();

        if (text.IndexOf("Build cancelled", StringComparison.Ordinal) >= 0 || text.StartsWith("Build has been canceled.", StringComparison.Ordinal))
        {
            result = BuildResultData.Canceled();
            return true;
        }

        if (!text.StartsWith("========== ", StringComparison.Ordinal))
        {
            return false;
        }

        if (!text.EndsWith(" ==========\r\n", StringComparison.Ordinal))
        {
            return false;
        }

        var regex = "^========== (?:Build|Rebuild All|Clean): (?<Succeeded>\\d+) succeeded(?: or up-to-date)?, (?<Failed>\\d+) failed, (?:(?<UpToDate>\\d+) up-to-date, )?(?<Skipped>\\d+) skipped ==========\r\n$";
        var match = Regex.Match(text, regex, RegexOptions.Compiled);
        if (!match.Success)
        {
            return false;
        }

        result = ParsedData.Create<BuildResultData>(match, span.Span);
        return true;
    }
}