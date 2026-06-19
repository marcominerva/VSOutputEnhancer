# 01-convert-vsix-project-file: Convert VSIX project file to SDK-style

Replace the legacy project structure with an SDK-style VSSDK project while preserving the existing package identity, target framework, project references, VSIX content, and shared version metadata. This includes migrating `Newtonsoft.Json` from `packages.config`/assembly reference to `PackageReference`, raising `Microsoft.VSSDK.BuildTools` to the SDK-style minimum, preserving `GeneratePkgDefFile=false`, and retaining VSIX-specific packaging metadata.

**Done when**: `VsixPackage/VsixPackage.csproj` uses `<Project Sdk="Microsoft.NET.Sdk">`, targets `net48`, includes SDK-style VSIX properties and `CreateVsixContainer`, contains required `PackageReference` items, preserves VSIX content/project references, has no legacy VSSDK imports or debug launch properties, and `VsixPackage/packages.config` is removed.

## Research Findings

### Projects Affected
- `VsixPackage/VsixPackage.csproj` — legacy VSSDK container project to convert to SDK-style. Referenced MEF component projects are preserved and not modified in this task.

### Files to Modify
- `VsixPackage/VsixPackage.csproj` — replace legacy MSBuild XML with SDK-style VSSDK configuration, migrate packages.config dependency, preserve VSIX content and project references.
- `VsixPackage/packages.config` — remove after migrating `Newtonsoft.Json` 7.0.1 to `PackageReference`.

### Packages to Update
| Package | Current | Target | Notes |
|---------|---------|--------|-------|
| `Newtonsoft.Json` | 7.0.1 (`packages.config` + assembly reference) | 7.0.1 (`PackageReference`) | Preserve version for format-only conversion. |
| `Microsoft.VisualStudio.SDK` | 17.0.0-previews-1-31410-273 | 17.0.0-previews-1-31410-273 | Existing version retained per VSSDK conversion guidance. |
| `Microsoft.VSSDK.BuildTools` | 17.0.2155-preview2 | 18.5.38461 | Must be raised to SDK-style VSIX minimum. |

### Dependencies & Risks
- No VSCT files were found, so no `VSCTCompile` items are needed.
- `source.extension.vsixmanifest` must remain as a `None` item with designer/generator metadata.
- VSIX content items (`License.txt`, `Icon.png`, `Preview.png`) must keep `IncludeInVSIX=true`.
- Project references to `VSOutputEnhancer.Logic` and `VSOutputEnhancer.UI` must preserve VSIX output group metadata on the UI reference.
- `GeneratePkgDefFile=false` and `IncludeAssemblyInVSIXContainer=false` are existing behavior and should be preserved.
- Baseline build/restore is already blocked by NuGet package source mapping and `global.json` SDK resolution issues; validation may remain blocked by those pre-existing environment/package-source issues.

### Decisions Made
- Preserve `net48` as the target framework.
- Keep package versions unchanged except for raising `Microsoft.VSSDK.BuildTools` to the required SDK-style minimum.
- Do not remove `Properties/AssemblyInfo.cs` in this task; that is handled by the next planned task.
