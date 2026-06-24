using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Utilities;

namespace Balakin.VSOutputEnhancer.Tests.Base.Stubs
{
    [ExcludeFromCodeCoverage]
    public class ContentTypeStub : IContentType
    {
        public ContentTypeStub(string typeName)
        {
            TypeName = typeName;
            DisplayName = $"Display name: {typeName}";
            BaseTypes = new List<IContentType>().AsReadOnly();
        }

        public bool IsOfType(string type)
        {
            return string.Equals(type, TypeName, StringComparison.OrdinalIgnoreCase);
        }

        public string TypeName { get; }
        public string DisplayName { get; }
        public IEnumerable<IContentType> BaseTypes { get; }
    }
}