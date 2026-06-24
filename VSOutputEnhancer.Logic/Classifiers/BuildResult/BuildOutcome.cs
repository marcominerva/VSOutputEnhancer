namespace Balakin.VSOutputEnhancer.Logic.Classifiers.BuildResult;

/// <summary>
/// Represents the overall outcome of a build, used to drive how a build result line is classified.
/// </summary>
public enum BuildOutcome
{
    /// <summary>The build completed without failures.</summary>
    Succeeded,

    /// <summary>The build failed or was canceled.</summary>
    Failed
}
