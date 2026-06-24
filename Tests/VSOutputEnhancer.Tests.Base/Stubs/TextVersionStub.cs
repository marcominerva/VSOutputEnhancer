using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Tests.Base.Stubs
{
    [ExcludeFromCodeCoverage]
    public class TextVersionStub : ITextVersion
    {
        public TextVersionStub(ITextBuffer textBuffer)
        {
            TextBuffer = textBuffer;
            VersionNumber = 0;
        }

        public ITrackingPoint CreateTrackingPoint(int position, PointTrackingMode trackingMode)
        {
            throw new NotImplementedException();
        }

        public ITrackingPoint CreateTrackingPoint(int position, PointTrackingMode trackingMode, TrackingFidelityMode trackingFidelity)
        {
            throw new NotImplementedException();
        }

        public ITrackingSpan CreateTrackingSpan(Span span, SpanTrackingMode trackingMode)
        {
            throw new NotImplementedException();
        }

        public ITrackingSpan CreateTrackingSpan(Span span, SpanTrackingMode trackingMode, TrackingFidelityMode trackingFidelity)
        {
            throw new NotImplementedException();
        }

        public ITrackingSpan CreateTrackingSpan(int start, int length, SpanTrackingMode trackingMode)
        {
            throw new NotImplementedException();
        }

        public ITrackingSpan CreateTrackingSpan(int start, int length, SpanTrackingMode trackingMode, TrackingFidelityMode trackingFidelity)
        {
            throw new NotImplementedException();
        }

        public ITrackingSpan CreateCustomTrackingSpan(Span span, TrackingFidelityMode trackingFidelity, Object customState, CustomTrackToVersion behavior)
        {
            throw new NotImplementedException();
        }

        public ITextVersion Next
        {
            get { throw new NotImplementedException(); }
        }

        public int Length
        {
            get { throw new NotImplementedException(); }
        }

        public INormalizedTextChangeCollection Changes
        {
            get { throw new NotImplementedException(); }
        }

        public ITextBuffer TextBuffer { get; }
        public int VersionNumber { get; }

        public int ReiteratedVersionNumber
        {
            get { throw new NotImplementedException(); }
        }
    }
}