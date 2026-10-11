# Compatibility and Verification Matrix

**Status: No compatibility claim is established until backed by evidence.**

Record only versions and operations that have actually been tested.

| Component / format | Version or fixture | Operation | Status | Evidence |
|---|---|---|---|---|
| .NET SDK | TBD | Restore/build/test | UNVERIFIED | Add CI run |
| UAssetAPI | TBD | Load UAsset | UNVERIFIED | Add minimal executable test |
| UAssetAPI | TBD | Read FunctionExport/bytecode | UNVERIFIED | Add fixture test |
| UAssetAPI | TBD | Write modified UAsset | UNVERIFIED | Re-read output |
| AssetRegistry | TBD | Parse | UNVERIFIED | Add fixture and structural assertions |
| AssetRegistry | TBD | Edit and write | UNVERIFIED | Round-trip structural test |
| Kismet expressions | TBD | Generate simple expression | UNVERIFIED | Golden fixture test |
| Control flow | TBD | Jump offset generation | UNVERIFIED | Serialized offset proof |
| Browser | TBD | File open/save | UNVERIFIED | Browser integration test |

## Evidence rules

- `PROPOSED`: design only.
- `IMPLEMENTED`: code exists, but correctness may not be proven.
- `TESTED`: automated or manual test actually ran and passed.
- `PARTIALLY SUPPORTED`: only a stated subset is verified.
- `UNVERIFIED`: no reliable test evidence yet.
- `UNSUPPORTED`: intentionally not supported.

Never mark a test as passed if it was skipped or could not run. Record environment limitations separately from code failures.
