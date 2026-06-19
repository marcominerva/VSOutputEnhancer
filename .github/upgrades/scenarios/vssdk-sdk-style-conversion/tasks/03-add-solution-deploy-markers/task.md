# 03-add-solution-deploy-markers: Add VSIX deploy markers to the solution

Update the classic solution file to mark the VSIX project as deployable for each existing solution configuration. This replaces the legacy `StartAction`/`StartProgram` debug launch pattern and enables F5 deployment together with `VsixDeployOnDebug=true`.

**Done when**: `VSOutputEnhancer.sln` contains `Deploy.0` entries for the VSIX project for Debug and Release Any CPU/x86/x64/ARM mappings, without changing other project configuration mappings.

## Research Findings

### Files to Modify
- `VSOutputEnhancer.sln` — classic solution file with `ProjectConfigurationPlatforms` entries for VSIX project `{EF89C340-CD9E-4DE7-902A-7361936F5BCB}`.

### Existing VSIX Configuration Mappings
- Debug configurations map to `Debug|Any CPU` for Any CPU, ARM, x64, and x86.
- Release configurations map to `Release|Any CPU` for Any CPU, ARM, x64, and x86.
- No existing `Deploy.0` entries were present for the VSIX project.

### Decisions Made
- Add one `Deploy.0` line after each VSIX `Build.0` mapping, using the same target configuration as the corresponding `Build.0` line.
- Do not modify any other project mappings.
