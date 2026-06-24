using System;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic.Classifiers;
using Balakin.VSOutputEnhancer.Logic.Classifiers.BuildFileRelatedMessage;
using Microsoft.VisualStudio.Text;

namespace Balakin.VSOutputEnhancer.Logic.Tests.Parsers.TestCases.BuildFileRelatedMessage
{
    [ExcludeFromCodeCoverage]
    public class NoBuildTaskId : TestCaseBase
    {
        public override string Input { get; } = "C:\\Some project path\\Product.wxs(83,0): warning CNDL1138: The RegistryKey/@Action attribute has been deprecated.  In most cases, you can simply omit @Action.  If you need to force Windows Installer to create an empty key or recursively delete the key, use the ForceCreateOnInstall or ForceDeleteOnUninstall attributes instead.\r\n";

        public override BuildFileRelatedMessageData ExpectedResult { get; } = new BuildFileRelatedMessageData(
            new ParsedValue<int>(),
            new ParsedValue<MessageType>(MessageType.Warning, new Span(40, 7)),
            new ParsedValue<string>("CNDL1138", new Span(48, 8)),
            new ParsedValue<string>("The RegistryKey/@Action attribute has been deprecated.  In most cases, you can simply omit @Action.  If you need to force Windows Installer to create an empty key or recursively delete the key, use the ForceCreateOnInstall or ForceDeleteOnUninstall attributes instead.", new Span(58, 268)),
            new ParsedValue<string>("warning CNDL1138: The RegistryKey/@Action attribute has been deprecated.  In most cases, you can simply omit @Action.  If you need to force Windows Installer to create an empty key or recursively delete the key, use the ForceCreateOnInstall or ForceDeleteOnUninstall attributes instead.", new Span(40, 286)),
            new ParsedValue<string>("C:\\Some project path\\Product.wxs", new Span(0, 32))
        );
    }
}