# 04-validate-vsix-conversion: Validate build and VSIX output

Clean stale VSIX build artifacts, restore/build the converted project, and verify that the SDK-style project produces a VSIX package without duplicate compile items or legacy import errors. Existing repository restore issues may still block full validation and should be recorded clearly if they remain unrelated to the conversion edits.

**Done when**: the VSIX project build succeeds and produces a `.vsix`, or any remaining build failure is documented with exact errors and confirmed to be caused by pre-existing environment/package-source issues rather than the SDK-style conversion.
