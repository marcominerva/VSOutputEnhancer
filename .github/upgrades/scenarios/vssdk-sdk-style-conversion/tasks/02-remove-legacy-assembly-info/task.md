# 02-remove-legacy-assembly-info: Remove legacy VSIX AssemblyInfo

Remove the VSIX project's explicit `Properties/AssemblyInfo.cs` file and represent its remaining assembly metadata through SDK-style project properties. Keep the linked shared `Build/GlobalAssemblyInfo.cs` because it provides common version metadata.

**Done when**: `VsixPackage/Properties/AssemblyInfo.cs` is removed from the project and repository, assembly title/description/company/product defaults are represented in the project file as needed, and no duplicate assembly attribute errors are introduced.
