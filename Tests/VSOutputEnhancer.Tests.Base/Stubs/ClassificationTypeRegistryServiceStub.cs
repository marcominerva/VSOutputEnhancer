using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.Text.Classification;

namespace Balakin.VSOutputEnhancer.Tests.Base.Stubs
{
    [Export(typeof(IClassificationTypeRegistryService))]
    [ExcludeFromCodeCoverage]
    public class ClassificationTypeRegistryServiceStub : IClassificationTypeRegistryService
    {
        public IClassificationType GetClassificationType(string type)
        {
            return new ClassificationTypeStub(type);
        }

        public IClassificationType CreateClassificationType(string type, IEnumerable<IClassificationType> baseTypes)
        {
            throw new NotImplementedException();
        }

        public IClassificationType CreateTransientClassificationType(IEnumerable<IClassificationType> baseTypes)
        {
            throw new NotImplementedException();
        }

        public IClassificationType CreateTransientClassificationType(params IClassificationType[] baseTypes)
        {
            throw new NotImplementedException();
        }
    }
}