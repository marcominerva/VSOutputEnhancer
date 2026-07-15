using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

namespace Balakin.VSOutputEnhancer.Tests.Base.Stubs
{
    [ExcludeFromCodeCoverage]
    public class TextSnapshotStub : ITextSnapshot
    {
        public TextSnapshotStub(string text)
        {
            this.text = text;
            TextBuffer = new TextBufferStub(null);
            Version = new TextVersionStub(TextBuffer);
            ((TextBufferStub)TextBuffer).CurrentSnapshot = this;
        }

        private string text;

        /// <summary>
        /// Appends text to the snapshot, simulating an append-only buffer such as the
        /// Visual Studio Output window. Returns the start position of the appended text.
        /// </summary>
        public int Append(string value)
        {
            var start = text.Length;
            text += value;
            return start;
        }

        #region ITextSnapshot

        public string GetText(Span span)
        {
            return GetText(span.Start, span.Length);
        }

        public string GetText(int startIndex, int length)
        {
            return text.Substring(startIndex, length);
        }

        public string GetText()
        {
            return text;
        }

        public Char[] ToCharArray(int startIndex, int length)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(int sourceIndex, Char[] destination, int destinationIndex, int count)
        {
            throw new NotImplementedException();
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

        public ITextSnapshotLine GetLineFromLineNumber(int lineNumber)
        {
            throw new NotImplementedException();
        }

        public ITextSnapshotLine GetLineFromPosition(int position)
        {
            throw new NotImplementedException();
        }

        public int GetLineNumberFromPosition(int position)
        {
            throw new NotImplementedException();
        }

        public void Write(TextWriter writer, Span span)
        {
            throw new NotImplementedException();
        }

        public void Write(TextWriter writer)
        {
            throw new NotImplementedException();
        }

        public ITextBuffer TextBuffer { get; }

        public IContentType ContentType
        {
            get { throw new NotImplementedException(); }
        }

        public ITextVersion Version { get; }

        public int Length
        {
            get { return text.Length; }
        }

        public int LineCount
        {
            get { throw new NotImplementedException(); }
        }

        public Char this[int position]
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<ITextSnapshotLine> Lines
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}