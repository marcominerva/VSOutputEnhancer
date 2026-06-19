# Assessment: VSSDK SDK-Style Conversion

## Target Project
| Property | Value |
|----------|-------|
| Project | VsixPackage |
| Path | `VsixPackage/VsixPackage.csproj` |
| Current TFM | `net48` (`TargetFrameworkVersion` v4.8) |
| Solution format | `.sln` |
| packages.config | Yes (`Newtonsoft.Json` 7.0.1) |

## VSIX Components Found
- [x] VSIX manifest (`VsixPackage/source.extension.vsixmanifest`)
- [ ] VSCT command table (none found)
- [ ] Tool windows (none found in VSIX project)
- [x] MEF exports (extension assets reference MEF component projects: `VSOutputEnhancer.Logic`, `VSOutputEnhancer.UI`)
- [ ] Custom editors (none found)
- [ ] Language services (none found)

## Current Package References
- `Microsoft.VisualStudio.SDK` 17.0.0-previews-1-31410-273 (`ExcludeAssets=runtime`)
- `Microsoft.VSSDK.BuildTools` 17.0.2155-preview2 — below SDK-style VSIX minimum; must be raised to at least 18.5.38461
- `Newtonsoft.Json` 7.0.1 from `packages.config` and assembly reference; must move to `PackageReference`

## Baseline
- Project builds: No
- Solution builds: No

Baseline build is currently blocked by package restore/source-mapping issues and global.json SDK resolution:
- `NU1100` for packages including `Microsoft.VisualStudio.SDK`, `Microsoft.VSSDK.BuildTools`, `VSSDK.Text`, and `Microsoft.NETFramework.ReferenceAssemblies`
- `NETSDK1141` resolving the SDK version specified by `global.json`
- Downstream `CS0006` metadata errors caused by referenced projects not building

## Key Findings
- The VSIX project is a legacy MSBuild project with `ProjectTypeGuids`, legacy imports, explicit compile items, `packages.config`, and debug launch properties.
- The project target framework is .NET Framework 4.8 and should remain `net48`.
- `GeneratePkgDefFile` is explicitly set to `false`; preserve this value during conversion.
- `IncludeAssemblyInVSIXContainer` is explicitly set to `false`; preserve it so the VSIX continues to package the two MEF component project assets instead of the container project assembly.
- There are no VSCT files to preserve.
- The VSIX manifest contains MEF component assets for `VSOutputEnhancer.Logic` and `VSOutputEnhancer.UI` plus content assets (`License.txt`, `Icon.png`, `Preview.png`) that must remain included in the VSIX.
- `Properties/AssemblyInfo.cs` only contains assembly metadata and `ComVisible(false)`; these can be represented as SDK-style project properties, allowing the file to be removed.
- `Build/GlobalAssemblyInfo.cs` is linked into the VSIX project and must remain linked because it provides shared version metadata.
- The `.sln` lacks VSIX deploy markers; add `Deploy.0` entries for the VSIX project so F5 deployment works with `VsixDeployOnDebug=true`.
