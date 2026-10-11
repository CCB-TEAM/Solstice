# Phase Task Template

Continue work on Solstice.

**Phase:** [phase name/number]

**Goal:** [one independently verifiable capability]

## Before implementation

1. Inspect existing code, documentation, package versions and working-tree state.
2. Verify the APIs relevant to this task.
3. List the files expected to change.
4. Define acceptance criteria.
5. Preserve unrelated user changes.

## Implementation constraints

- Follow `AGENTS.md` and `docs/architecture.md`.
- Do not guess dependency APIs.
- Do not add fake implementations or inert UI controls.
- Preserve one-way UKAPI generation.
- Never reuse package-local indices across assets.
- Return structured diagnostics for expected failures.
- Add automated tests for the new behavior.
- Keep changes focused.

## Before completion

1. Run relevant tests.
2. Run a full build where possible.
3. Fix regressions caused by this change.
4. Update the relevant docs.
5. Report modified files and actual command results.
6. List known limitations and unverified behavior.

Do not mark the task complete if acceptance criteria are not met. Work directly in the repository; do not return only suggested code.
