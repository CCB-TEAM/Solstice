# ADR 0001: UKAPI is a One-Way Generator

- Status: Accepted as a project design principle
- Date: 2026-10-11

## Context

A full cooked Blueprint decompiler and bidirectional semantic round-trip editor would substantially expand the scope and uncertainty of the project.

## Decision

UKAPI consumes high-level function descriptions and generates supported Kismet structures. It does not promise to convert arbitrary existing bytecode back into the same high-level representation.

Read-only bytecode parsing remains allowed for inspection, target discovery and validation.

## Consequences

Positive:
- A smaller and more testable compiler surface.
- Focus on fast function generation/replacement.
- Less pressure to reconstruct every editor-only Blueprint semantic.

Trade-offs:
- Existing functions are not generally editable through a lossless high-level reconstruction.
- Supported generation capabilities must be explicit.
- Bytecode parsing is still needed for inspection and validation.
