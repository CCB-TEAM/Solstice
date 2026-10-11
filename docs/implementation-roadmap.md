# Implementation Roadmap

**Status: Proposed plan. Dates and effort are estimates, not commitments.**

## Phase 0 — Repository and API reconnaissance

Tasks:
- Inspect the existing repository, SDK, package versions and build environment.
- Verify the actual UAssetAPI APIs needed for UAsset loading, FunctionExport discovery, bytecode access, and serialization.
- Verify whether the selected library supports the target AssetRegistry read/edit/write workflow.
- Build minimal proof programs before designing wrappers around unverified APIs.
- Record known formats, versions, and gaps.

Acceptance:
- Clean build and test baseline.
- API facts supported by source, documentation, or executable proof.
- Highest-risk assumptions recorded in compatibility notes.
- No guessed API in core implementation.

## Phase 1 — Workspace foundation

Tasks:
- Establish solution structure and package version management.
- Add Blazor client and shared domain/application projects as justified by actual code.
- Implement file selection, loading/error/cancel states, logging, and safe output selection.
- Add automated tests and CI.

Acceptance:
- App starts.
- File loading failures are understandable.
- Build and tests run in a clean environment.

## Phase 2 — AssetRegistry workflow

Tasks:
- Parse actual supported AssetRegistry data.
- Present searchable entries and fields.
- Edit only fields known to be safely writable.
- Validate and save to a new file.
- Re-read and validate output.

Acceptance:
- A permitted fixture completes open → inspect → edit → save → reopen.
- Unsupported formats are not silently rewritten.

## Phase 3 — Read-only UAsset inspector

Tasks:
- Load a UAsset.
- Display package summary, Imports and Exports.
- Locate supported FunctionExport objects.
- Render a read-only expression tree with details and search.
- Provide explicit fallback diagnostics for unknown expressions.

Acceptance:
- Fixtures can be inspected without crashing the whole UI on an unsupported expression.
- Displayed facts can be traced to actual parsed data.

## Phase 4 — UKAPI minimum generator

Tasks:
- Define FunctionDescription, signature, local variables, statements, arguments, and symbol identities.
- Add semantic validation.
- Support a deliberately small set of expressions first.
- Construct actual expressions through verified APIs.
- Add deterministic tests and diagnostics.

Acceptance:
- At least one simple supported function is generated reproducibly.
- Invalid descriptions fail with actionable diagnostics.
- Tests do not pretend that generation implies runtime correctness.

## Phase 5 — AssetLinker and replacement

Tasks:
- Resolve symbols by package path, owner type, function name and signature when available.
- Search current package Imports/Exports.
- Construct and deduplicate the correct Import chain.
- Bind actual package-local FPackageIndex values.
- Preview the replacement.
- Write to a new file and re-read it.

Acceptance:
- A legally distributable fixture completes the replacement workflow.
- All generated references pass implemented checks.
- The output can be re-read by the chosen parser.
- Runtime behavior is reported separately and requires target-engine/project validation.

## Phase 6 — Metadata preprocessing and expansion

Tasks:
- Add JMAP indexing and versioned index artifacts.
- Add optional UHT signature extraction or manual signature import.
- Add supported expressions and control flow incrementally.
- Maintain a UE/version compatibility matrix.
- Measure memory and startup costs before optimization.

Acceptance:
- Each newly supported capability has tests, documented scope and a reproducible validation path.

## Prioritization rule

Prefer a small end-to-end vertical slice over many untested modules. Verify UAssetAPI, AssetRegistry, bytecode generation and Import construction early; they are higher risk than the UI.
