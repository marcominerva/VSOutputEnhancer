using System;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers
{
    public interface IParser<T> where T : ParsedData
    {
        bool TryParse(SnapshotSpan span, out T result);
    }
}