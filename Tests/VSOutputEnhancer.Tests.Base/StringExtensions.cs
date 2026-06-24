using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Tests.Base.Stubs;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Tests.Base
{
    [ExcludeFromCodeCoverage]
    public static class stringExtensions
    {
        public static SnapshotSpan ToSnapshotSpan(this string s)
        {
            var snapshot = new TextSnapshotStub(s);
            var span = new SnapshotSpan(snapshot, new Span(0, snapshot.Length));
            return span;
        }
    }
}