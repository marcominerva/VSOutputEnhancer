using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic
{
    public interface ISpanClassifier
    {
        IEnumerable<string> ContentTypes { get; }
        IEnumerable<ProcessedParsedData> Classify(SnapshotSpan span, IDispatcher dispatcher);
    }
}