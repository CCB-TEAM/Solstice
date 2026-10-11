# Solstice

**Solstice** is a technical concept repository for research, architecture notes, implementation plans, Harness prompts, and isolated code experiments around Unreal Engine cooked assets and one-way Kismet bytecode generation.

> **Status: Concept / early engineering plan.** This repository does not claim that every planned capability is implemented or validated.

## Project direction

Solstice explores a browser-first workflow for inspecting Unreal Engine cooked assets and generating/replacing selected function bytecode through a one-way API.

Core principles:

- **One-way generation:** high-level function descriptions compile into supported Kismet structures. Existing bytecode is not promised to round-trip through a decompiler.
- **Asset-local references:** `FPackageIndex` values belong to a specific package. Global metadata must never be treated as a substitute for the current asset's Import/Export tables.
- **Evidence before implementation:** verify actual UAssetAPI APIs, target UE versions, and serialization behavior against real fixtures.
- **Safe writeback:** generate into a separate output, validate it, then re-read it before declaring success.
- **Honest capability reporting:** unsupported expressions and unverified behavior must be clearly marked.

## Repository map

- [`docs/architecture.md`](docs/architecture.md) — system boundaries and core design decisions.
- [`docs/implementation-roadmap.md`](docs/implementation-roadmap.md) — staged delivery plan and acceptance criteria.
- [`docs/compatibility.md`](docs/compatibility.md) — evidence-based compatibility matrix.
- [`docs/bytecode-generation.md`](docs/bytecode-generation.md) — generation and validation rules.
- [`prompts/harness-master-prompt.md`](prompts/harness-master-prompt.md) — master prompt for coding agents.
- [`prompts/phase-task-template.md`](prompts/phase-task-template.md) — reusable phase task prompt.
- [`snippets/`](snippets/) — small, independently documented code concepts.
- [`experiments/`](experiments/) — experiments, observations, and unresolved questions.
- [`docs/decisions/`](docs/decisions/) — architecture decision records.

## Initial status

| Area | Status |
|---|---|
| Product and architecture concept | Drafted |
| Harness prompts | Initial draft |
| UAssetAPI API verification | Not yet recorded |
| AssetRegistry read/write validation | Not yet recorded |
| Kismet generation validation | Not yet recorded |
| Real asset integration tests | Not yet recorded |
| Browser UI | Not implemented in this concept repository |

## Working rules

1. Do not commit game assets or other files without clear redistribution rights.
2. Do not claim a test passed unless it was actually run and its result recorded.
3. Do not invent APIs, expression layouts, byte offsets, or compatibility claims.
4. Keep conceptual proposals separate from validated experiments.
5. Prefer small end-to-end vertical slices over large untested code drops.

## Suggested first milestone

Validate the actual toolchain and one minimal asset workflow before building out the full UI:

1. Pin the .NET SDK and dependency versions.
2. Verify UAssetAPI's actual support for the intended AssetRegistry and UAsset operations.
3. Load a legally distributable fixture.
4. Locate a target function export and inspect the available bytecode representation.
5. Prototype generation of one simple supported function.
6. Write to a new file, re-read it, and record the results.

See the [implementation roadmap](docs/implementation-roadmap.md).
