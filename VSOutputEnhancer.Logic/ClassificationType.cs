namespace Balakin.VSOutputEnhancer.Logic
{
    public static class ClassificationType
    {
        public static readonly string[] All =
        [
            BuildMessageError,
            BuildMessageWarning,
            BuildProjectHeader,
            BuildResultFailed,
            BuildResultSucceeded,
            PublishResultFailed,
            PublishResultSucceeded,
            DebugTraceError,
            DebugTraceWarning,
            DebugTraceInformation,
            DebugException,
            NpmResultFailed,
            NpmResultSucceeded,
            NpmMessageWarning,
            NpmMessageError,
            BowerMessageError
        ];

        public const string BuildMessageError = "BuildMessageError";
        public const string BuildMessageWarning = "BuildMessageWarning";
        public const string BuildProjectHeader = "BuildProjectHeader";

        public const string BuildResultFailed = "BuildResultFailed";
        public const string BuildResultSucceeded = "BuildResultSucceeded";

        public const string PublishResultFailed = "PublishResultFailed";
        public const string PublishResultSucceeded = "PublishResultSucceeded";

        public const string DebugTraceError = "DebugTraceError";
        public const string DebugTraceWarning = "DebugTraceWarning";
        public const string DebugTraceInformation = "DebugTraceInformation";
        public const string DebugException = "DebugException";

        public const string NpmResultFailed = "NpmResultFailed";
        public const string NpmResultSucceeded = "NpmResultSucceeded";

        public const string NpmMessageWarning = "NpmMessageWarning";
        public const string NpmMessageError = "NpmMessageError";

        public const string BowerMessageError = "BowerMessageError";
    }
}