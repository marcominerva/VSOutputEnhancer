using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Balakin.VSOutputEnhancer.Logic;

namespace Balakin.VSOutputEnhancer.IntegrationTests.TestCases
{
    [ExcludeFromCodeCoverage]
    public class RebuildOrderOutput : ITestCase
    {
        public string ContentType { get; } = Logic.ContentType.BuildOrderOutput;

        public IReadOnlyList<string> SourceText { get; } = new[]
        {
            "1>------ Rebuild All started: Project: ClassLibrary1, Configuration: Debug Any CPU ------\r\n",
            "1>Restored C:\\Temp\\ConsoleApp2\\ClassLibrary1\\ClassLibrary1.csproj (in 722 ms).\r\n",
            "========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========\r\n"
        };

        public IReadOnlyList<ClassifiedText> ExpectedResult { get; } = new[]
        {
            new ClassifiedText(ClassificationType.BuildActionStartedSuccess, "------ Rebuild All started: Project: ClassLibrary1, Configuration: Debug Any CPU ------"),
            new ClassifiedText(ClassificationType.BuildResultSucceeded, "========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========\r\n")
        };
    }
}
