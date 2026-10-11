# Repository Instructions for Coding Agents

## Mission

Develop Solstice incrementally as an evidence-driven technical project. Inspect the current repository before changing it. Preserve existing work.

## Non-negotiable design rules

- UKAPI is a **one-way high-level description → Kismet generation** API, not a bidirectional decompiler.
- Read-only bytecode parsing may be used for target discovery, inspection, and validation; it does not imply semantic round-tripping.
- The target asset's Import/Export tables are authoritative for package-local references.
- Never reuse `FPackageIndex` values across different assets.
- Never assume an Import's `OuterIndex` is always zero.
- Never assume expression array indices are byte offsets for jump instructions.
- Do not guess UAssetAPI types, constructors, properties, or methods. Verify the exact package version and API first.
- Never fake parsing, serialization, validation, or test results.
- Do not claim runtime correctness based only on successful serialization.
- Do not overwrite the input asset by default. Write a new output and re-read it for validation.
- Do not add copyrighted game assets or secrets to the repository.

## Engineering workflow

For each task:

1. Inspect relevant source, docs, dependency versions, and working-tree state.
2. State the task goal and acceptance criteria.
3. Make the smallest coherent implementation.
4. Add or update automated tests.
5. Run relevant tests and a full build when possible.
6. Report the actual commands and results; distinguish failures caused by environment constraints.
7. Update docs and compatibility notes.
8. List limitations and remaining work.

Do not create many empty projects or placeholder classes just to make the tree look complete. A feature is complete only when its core path exists, its behavior is tested, errors are diagnosable, and documentation matches reality.

## Suggested dependency boundaries

- UI depends on application workflows.
- Domain logic does not depend on Blazor.
- UAssetAPI-specific behavior stays in infrastructure adapters.
- UKAPI core generation is independently testable.
- Metadata indexes describe global symbol identity; asset-local linking resolves references in the current package.

## Status labels

Use explicit labels such as `PROPOSED`, `IMPLEMENTED`, `TESTED`, `PARTIALLY SUPPORTED`, and `UNVERIFIED`. Do not silently upgrade a proposal into a validated capability.
