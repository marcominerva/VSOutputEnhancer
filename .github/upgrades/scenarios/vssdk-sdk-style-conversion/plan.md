# VSSDK SDK-Style Conversion Plan

## Overview

**Target**: Convert `VsixPackage/VsixPackage.csproj` from legacy VSSDK project format to SDK-style format.
**Scope**: One VSIX container project plus solution deploy marker updates. The referenced MEF component projects remain unchanged.

## Tasks

### 01-convert-vsix-project-file: Convert VSIX project file to SDK-style

Replace the legacy project structure with an SDK-style VSSDK project while preserving the existing package identity, target framework, project references, VSIX content, and shared version metadata. This includes migrating `Newtonsoft.Json` from `packages.config`/assembly reference to `PackageReference`, raising `Microsoft.VSSDK.BuildTools` to the SDK-style minimum, preserving `GeneratePkgDefFile=false`, and retaining VSIX-specific packaging metadata.

**Done when**: `VsixPackage/VsixPackage.csproj` uses `<Project Sdk="Microsoft.NET.Sdk">`, targets `net48`, includes SDK-style VSIX properties and `CreateVsixContainer`, contains required `PackageReference` items, preserves VSIX content/project references, has no legacy VSSDK imports or debug launch properties, and `VsixPackage/packages.config` is removed.

---

### 02-remove-legacy-assembly-info: Remove legacy VSIX AssemblyInfo

Remove the VSIX project's explicit `Properties/AssemblyInfo.cs` file and represent its remaining assembly metadata through SDK-style project properties. Keep the linked shared `Build/GlobalAssemblyInfo.cs` because it provides common version metadata.

**Done when**: `VsixPackage/Properties/AssemblyInfo.cs` is removed from the project and repository, assembly title/description/company/product defaults are represented in the project file as needed, and no duplicate assembly attribute errors are introduced.

---

### 03-add-solution-deploy-markers: Add VSIX deploy markers to the solution

Update the classic solution file to mark the VSIX project as deployable for each existing solution configuration. This replaces the legacy `StartAction`/`StartProgram` debug launch pattern and enables F5 deployment together with `VsixDeployOnDebug=true`.

**Done when**: `VSOutputEnhancer.sln` contains `Deploy.0` entries for the VSIX project for Debug and Release Any CPU/x86/x64/ARM mappings, without changing other project configuration mappings.

---

### 04-validate-vsix-conversion: Validate build and VSIX output

Clean stale VSIX build artifacts, restore/build the converted project, and verify that the SDK-style project produces a VSIX package without duplicate compile items or legacy import errors. Existing repository restore issues may still block full validation and should be recorded clearly if they remain unrelated to the conversion edits.

**Done when**: the VSIX project build succeeds and produces a `.vsix`, or any remaining build failure is documented with exact errors and confirmed to be caused by pre-existing environment/package-source issues rather than the SDK-style conversion.
