# VSSDK SDK-Style Conversion

## Preferences
- **Flow Mode**: Automatic
- **Scenario**: Convert the VSIX/VSSDK project to SDK-style format while preserving VSIX packaging and F5 deployment.
- **Target Project**: `VsixPackage/VsixPackage.csproj`
- **Target Framework**: Unchanged (format-only conversion)

## Source Control
- **Source Branch**: `master`
- **Working Branch**: `vssdk-sdk-style-conversion`
- **Pending Changes Action**: Commit before switching branches
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## References
- Visual Studio SDK-style support for extension projects blog: https://devblogs.microsoft.com/visualstudio/sdk-style-support-for-extension-projects/

## User Preferences
### Technical Preferences
- **Compatibility**: Backward compatibility with `net45` is not required; prioritize compatibility with Visual Studio 2026.

## Key Decisions Log
- **2026-06-22**: User confirmed the project only needs to work with Visual Studio 2026; future package/framework modernization can drop .NET Framework 4.5 constraints.
- **2026-06-22**: User approved applying the recommended next steps: retarget `net45` projects to `net48` and update NuGet packages that were blocked by .NET Framework 4.5 compatibility.
- **2026-06-22**: User explicitly requested replacing legacy `xunit` with `xunit.v3` for test projects.
- **2026-06-22**: User approved repairing malformed test `.csproj` files and completing restore/build/test validation after the xUnit v3 migration.
- **2026-06-22**: User requires `dotnet test VSOutputEnhancer.slnx --no-build` to work successfully with xUnit v3; recreating test projects is acceptable if needed.
- **2026-06-22**: User requested using a stable non-preview `xunit.v3` package version.
