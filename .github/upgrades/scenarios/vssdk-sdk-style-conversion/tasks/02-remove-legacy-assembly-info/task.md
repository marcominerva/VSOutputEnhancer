# 02-remove-legacy-assembly-info: Remove legacy VSIX AssemblyInfo

Remove the VSIX project's explicit `Properties/AssemblyInfo.cs` file and represent its remaining assembly metadata through SDK-style project properties. Keep the linked shared `Build/GlobalAssemblyInfo.cs` because it provides common version metadata.

**Done when**: `VsixPackage/Properties/AssemblyInfo.cs` is removed from the project and repository, assembly title/description/company/product defaults are represented in the project file as needed, and no duplicate assembly attribute errors are introduced.

## Research Findings

### Projects Affected
- `VsixPackage/VsixPackage.csproj` — SDK-style project now auto-generates assembly attributes unless disabled per attribute.

### Files to Modify
- `VsixPackage/VsixPackage.csproj` — add project properties for the metadata currently in `Properties/AssemblyInfo.cs` and disable generated attributes already provided by linked shared assembly info.
- `VsixPackage/Properties/AssemblyInfo.cs` — remove the legacy assembly info source file.

### Existing Metadata
- `VsixPackage/Properties/AssemblyInfo.cs` defines `AssemblyTitle`, `AssemblyDescription`, and `ComVisible(false)`.
- `Build/GlobalAssemblyInfo.cs` remains linked into the VSIX project and defines company, product, copyright, trademark, culture, configuration, assembly version, and file version.

### Decisions Made
- Keep `Build/GlobalAssemblyInfo.cs` linked because it provides shared version metadata.
- Add `AssemblyTitle`, `Description`, and `ComVisible` project properties for the VSIX-specific metadata.
- Disable SDK-generated attributes that would duplicate the linked shared assembly attributes from `Build/GlobalAssemblyInfo.cs`.
