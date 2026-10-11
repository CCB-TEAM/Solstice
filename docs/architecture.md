# Solstice Architecture

**Status: PROPOSED — not yet validated against a complete implementation.**

## 1. Product scope

Solstice is a concept and engineering workspace for a browser-first Unreal Engine cooked-asset toolkit. The planned tool combines asset inspection with one-way generation and replacement of selected function bytecode.

It is not intended to be a full Blueprint decompiler or a bidirectional semantic round-trip editor.

## 2. Main workflows

### Read-only inspection

`Local file → asset adapter → asset model → inspector → read-only expression tree`

The inspector can locate target objects, display Import/Export data, and expose supported bytecode structure. Unknown expressions should be shown as unsupported or partially understood rather than assigned fabricated semantics.

### Generation and replacement

`FunctionDescription → semantic validation → UKAPI → AssetLinker → OutputValidator → replacement preview → serialize to new file → re-read and validate`

Every stage must produce actionable diagnostics. A failed stage must prevent the writeback workflow from being reported as successful.

## 3. Proposed modules

- **Client:** Blazor UI, file selection, workspace state, inspectors, generator forms, progress and diagnostics.
- **Domain:** asset/function identities, descriptions, statements, arguments, diagnostics and validation result types.
- **Application:** workflows, orchestration, save policy and application services.
- **UAssetAPI infrastructure:** version-specific parsing, expression construction, serialization and compatibility adapters.
- **UKAPI:** one-way compilation from high-level function descriptions into supported Kismet structures.
- **AssetLinker:** resolve semantic symbol identities against the current asset and build valid package-local references.
- **Metadata:** JMAP loading/indexing, optional UHT signature extraction, and metadata preprocessing.
- **CLI:** offline index-building and validation commands, if useful.
- **Tests:** unit, integration and fixture-based regression tests.

## 4. Metadata versus package-local references

JMAP and optional UHT parsing may provide global symbol identity, function signatures, types, inheritance and package paths.

They do not replace the current UAsset's Import/Export tables. `FPackageIndex` is package-local. Resolve the symbol identity first, then find or construct the correct local import/export relationship for the target asset.

Import identity must account for object identity and the Outer chain, not only a leaf function name.

## 5. UKAPI is one-way

UKAPI consumes a high-level description and generates supported bytecode structures. It does not promise to reconstruct an existing function into the same high-level model.

Read-only bytecode parsing remains useful for target discovery, inspection, and post-write validation.

## 6. Control flow and offsets

Do not assume `EX_Jump` or `EX_JumpIfNot` offsets equal expression-list indices. Determine the target-version serialization rules from the actual dependency implementation and verified fixtures. If correct offset handling is not implemented and tested, disable that generation capability.

## 7. Validation layers

1. Input model: required fields, variable declarations, argument counts, supported statement shapes.
2. Generated structure: expression types, required fields, nesting and control-flow targets.
3. References: valid indices, expected object types, function identity and Outer relationships.
4. Serialized output: re-read the output, confirm the target function and expected structures, and detect unexpected collateral changes where practical.

Do not claim full VM stack verification unless it is actually implemented.

## 8. Safe writeback

- Preserve the original input.
- Work on an isolated asset instance or safe copy.
- Validate before mutation is committed to the output.
- Show a replacement summary.
- Write to a new output path by default.
- Re-read the output and run post-serialization checks.
- Distinguish parseability from runtime correctness.

## 9. Proposed dependency direction

`Client → Application → Domain`

Infrastructure adapters implement interfaces used by the application. UKAPI should depend on domain models and explicit linking/serialization abstractions, not on UI components.

The exact project references must follow the actual implementation and be kept free of unnecessary circular dependencies.
