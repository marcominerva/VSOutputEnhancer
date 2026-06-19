# 04-validate-vsix-conversion: Validate build and VSIX output

Clean stale VSIX build artifacts, restore/build the converted project, and verify that the SDK-style project produces a VSIX package without duplicate compile items or legacy import errors. Existing repository restore issues may still block full validation and should be recorded clearly if they remain unrelated to the conversion edits.

**Done when**: the VSIX project build succeeds and produces a `.vsix`, or any remaining build failure is documented with exact errors and confirmed to be caused by pre-existing environment/package-source issues rather than the SDK-style conversion.

## Research Findings

### Files Checked
- `VsixPackage/VsixPackage.csproj` — SDK-style project with `net48`, VSSDK properties, `CreateVsixContainer`, VSIX manifest/content/project references, and required package references.
- `VSOutputEnhancer.sln` — contains `Deploy.0` entries for the VSIX project across Debug/Release Any CPU, ARM, x64, and x86 mappings.
- `.github/upgrades/scenarios/vssdk-sdk-style-conversion/assessment.md` — baseline build was already blocked by package source mapping and `global.json` SDK resolution.

### Validation Focus
- Clean `VsixPackage/bin` and `VsixPackage/obj` after the VSSDK build tools update.
- Reload the converted VSIX project in Visual Studio before validation.
- Build `VsixPackage/VsixPackage.csproj` and determine whether failures are conversion-related or the same pre-existing restore/global.json blockers recorded in the baseline.

### Pre-Build Static Checks
- No legacy `ProjectTypeGuids`, `StartAction`, `StartProgram`, `StartArguments`, `TargetFrameworkVersion`, `Microsoft.Common.props`, `Microsoft.CSharp.targets`, `Microsoft.VsSDK.targets`, or `packages.config` references remain in the VSIX project.
- Target framework remains `net48`.
- Solution deploy markers are present.
