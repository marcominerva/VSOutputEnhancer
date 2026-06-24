using System;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.NpmResult
{
    // TODO: Review accessibility level
    public class NpmResultData : ParsedData
    {
        // TODO: Refactor ParsedData builder to get rid of this constructor
        public NpmResultData()
        {
        }

        public NpmResultData(ParsedValue<int> exitCode)
        {
            ExitCode = exitCode;
        }

        public ParsedValue<int> ExitCode { get; set; }
    }
}