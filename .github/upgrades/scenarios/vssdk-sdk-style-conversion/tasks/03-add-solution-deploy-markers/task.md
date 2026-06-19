# 03-add-solution-deploy-markers: Add VSIX deploy markers to the solution

Update the classic solution file to mark the VSIX project as deployable for each existing solution configuration. This replaces the legacy `StartAction`/`StartProgram` debug launch pattern and enables F5 deployment together with `VsixDeployOnDebug=true`.

**Done when**: `VSOutputEnhancer.sln` contains `Deploy.0` entries for the VSIX project for Debug and Release Any CPU/x86/x64/ARM mappings, without changing other project configuration mappings.
