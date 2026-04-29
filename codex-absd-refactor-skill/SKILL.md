---
name: codex-absd-refactor
description: Drive architecture-based software development (ABSD) refactoring for Buff-In-TopDownShooter. Use when the user asks to analyze, redesign, or implement phased refactors in this Unity project, especially when requests include architecture views, quality attributes, migration steps, or strict change boundaries.
---

# Codex ABSD Refactor Skill

Follow this workflow for this repository.

## 1) Normalize Input

Require or infer these fields from the user request:

- `goal`: what to change
- `scope`: allowed files/directories
- `constraints`: forbidden edits, compatibility requirements
- `acceptance`: how success is verified

If missing, infer conservative defaults and state assumptions.

## 2) ABSD Execution Order

Execute in this fixed order:

1. Capture architecture drivers (quality attributes + key scenarios).
2. Map current structure (modules, ownership, dependencies).
3. Propose target architecture slice for current task only.
4. Plan incremental migration with rollback-safe steps.
5. Implement minimal code changes for the current slice.
6. Verify behavior and summarize residual risks.

Do not perform broad rewrites when a narrow slice is requested.

## 3) Project-Specific Guardrails

- Preserve gameplay behavior unless user asks for behavior change.
- Prefer editing under `Assets/Scripts` and avoid generated Unity folders (`Library`, `Temp`, `Logs`, `obj`).
- Do not introduce runtime-wide singleton lookups if avoidable.
- Keep additions type-safe where possible; avoid new stringly-typed dispatch unless necessary for compatibility.
- If adding skill-like gameplay content, keep runtime core unchanged and add data/config first.

## 4) Output Contract

For substantial requests, output sections in this order:

1. `Architecture Drivers`
2. `Current vs Target`
3. `Change Plan`
4. `Implemented Changes`
5. `Verification`
6. `Risks / Next Slice`

For small requests, return only `Implemented Changes` and `Verification`.

## 5) Templates

Use:

- `references/request-template.md` to structure user intent.
- `references/review-template.md` to structure ABSD review output.

