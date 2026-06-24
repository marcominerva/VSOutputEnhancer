using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BowerMessage
{
    public class BowerMessageData : ParsedData
    {
        public ParsedValue<string> PackageName { get; set; }
        public ParsedValue<string> PackageVersion { get; set; }
        public ParsedValue<MessageType> Type { get; set; }
        public ParsedValue<string> ErrorCode { get; set; }
        public ParsedValue<string> Message { get; set; }

        protected override void Fill(Match match, Span originalSpan)
        {
            base.Fill(match, originalSpan);

            if (ErrorCode.HasValue)
            {
                Type = new ParsedValue<MessageType>(MessageType.Error, ErrorCode.Span);
            }
        }
    }
}