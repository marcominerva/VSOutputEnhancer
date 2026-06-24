using System;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult
{
    public class BuildResultData : ParsedData
    {
        // TODO: Refactor ParsedData builder to get rid of this constructor
        public BuildResultData()
        {
        }

        public BuildResultData(
            ParsedValue<Int32> succeeded,
            ParsedValue<Int32> failed,
            ParsedValue<Int32> upToDate,
            ParsedValue<Int32> skipped)
        {
            Succeeded = succeeded;
            Failed = failed;
            UpToDate = upToDate;
            Skipped = skipped;
        }

        /// <summary>
        /// Creates a <see cref="BuildResultData"/> for a build that was canceled or aborted.
        /// The <see cref="Outcome"/> is set to <see cref="BuildOutcome.Failed"/> directly,
        /// without relying on a synthetic failed-project count.
        /// </summary>
        public static BuildResultData Canceled() =>
            new()
            {
                Outcome = BuildOutcome.Failed
            };

        public ParsedValue<Int32> Succeeded { get; private set; } = new();
        public ParsedValue<Int32> Failed { get; private set; } = new();
        public ParsedValue<Int32> UpToDate { get; private set; } = new();
        public ParsedValue<Int32> Skipped { get; private set; } = new();

        private BuildOutcome? outcome;

        /// <summary>
        /// Gets the overall build outcome used to drive classification (such as coloring).
        /// When not set explicitly (for example, for a canceled build) it is inferred from
        /// <see cref="Failed"/>: any failed project results in <see cref="BuildOutcome.Failed"/>.
        /// </summary>
        public BuildOutcome Outcome
        {
            get => outcome ?? (Failed is { HasValue: true, Value: > 0 } ? BuildOutcome.Failed : BuildOutcome.Succeeded);
            private set => outcome = value;
        }
    }
}