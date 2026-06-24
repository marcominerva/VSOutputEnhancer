using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.Tests.Base.Stubs
{
    [ExcludeFromCodeCoverage]
    public class ClassificationTypeStub : IClassificationType
    {
        private readonly string type;

        public ClassificationTypeStub(string type)
        {
            this.type = type;
        }

        public bool IsOfType(string type)
        {
            return this.type.Equals(type, StringComparison.OrdinalIgnoreCase);
        }

        public string Classification => type;

        public IEnumerable<IClassificationType> BaseTypes
        {
            get { yield break; }
        }
    }
}