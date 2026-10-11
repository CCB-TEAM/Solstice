# Bytecode Generation Notes

**Status: Design notes; all format-specific behavior requires verification.**

## Intended pipeline

1. Validate FunctionDescription.
2. Resolve symbol identities and signatures.
3. Validate variables and arguments.
4. Build control-flow labels.
5. Construct supported UAssetAPI expression objects.
6. Calculate serialized layout where needed.
7. Validate expression structure and references.
8. Replace the target function in an isolated asset copy.
9. Serialize to a new file.
10. Re-read and validate the output.

## Symbol references

A function reference should carry more than a short name. Prefer package/module path, owner class, function name, signature or signature fingerprint, and any required target-object context.

Ambiguous matches must produce diagnostics instead of silently choosing one.

## Import construction

- Search the current package's Exports and Imports first.
- Deduplicate by full object identity and Outer chain.
- Construct the necessary outer/package/class/function relationships according to the actual target version and fixture evidence.
- Never copy package-local FPackageIndex values from global metadata or another asset.

## Control flow

Jump offset representation and serialization rules are version-sensitive. Never assume an expression list index is a byte offset. Verify the behavior against the actual UAssetAPI implementation and a real serialized fixture. Disable unsupported control-flow generation until this is proven.

## Validation

A successful serializer call is not sufficient. Re-read the output and check target function identity, supported expression structure, reference validity, and unexpected structural changes. Runtime correctness requires a separate target-engine or target-project validation step.
