---
name: codex-absd-refactor
description: Drive OpenSpec-backed ABSD work for this Unity top-down shooting game framework migration. Use when the user asks to reverse-analyze requirements, create or update OpenSpec changes, redesign architecture, migrate gameplay systems toward data/framework authoring, or implement bounded refactor slices.
---

# Codex OpenSpec ABSD Skill

Follow this workflow for this repository.

## 1) Load Project Truth

Read these first for substantial work:

1. `AGENTS.md`
2. `openspec/project.md`
3. Relevant current specs under `openspec/specs`
4. Relevant active changes under `openspec/changes`
5. `docs/absd/*` only as historical architecture notes

Use this ownership split:

- OpenSpec owns requirements, current facts, and proposed changes.
- `AGENTS.md` owns standing project rules.
- This skill owns reusable execution flow.

## 2) Normalize Input

Require or infer these fields from the user request:

- `goal`: what to change
- `scope`: allowed files/directories
- `constraints`: forbidden edits, compatibility requirements
- `acceptance`: how success is verified
- `openspec`: existing change id or whether a new change is needed

If missing, infer conservative defaults and state assumptions.

## 3) OpenSpec Gate

Before editing runtime code for a meaningful change:

1. Identify affected capability specs.
2. Create or update `openspec/changes/<change-id>/`.
3. Write `proposal.md`, `tasks.md`, optional `design.md`, and delta specs.
4. Use requirement language with `SHALL` or `MUST`.
5. Use scenarios with `GIVEN`, `WHEN`, and `THEN`.

Skip the gate only for tiny documentation fixes, mechanical formatting, or user-explicit exploratory reading.

## 4) Reverse Analysis Order

When the user asks to derive requirements from code:

1. Map runtime entry points and manager loops.
2. Extract domain concepts and invariants.
3. Separate current implemented facts from target requirements.
4. Put implemented facts in `openspec/specs`.
5. Put desired future behavior in `openspec/changes`.
6. Record uncertainty as open questions, not as fact.

## 5) ABSD Execution Order

Execute in this fixed order:

1. Capture architecture drivers (quality attributes + key scenarios).
2. Map current structure (modules, ownership, dependencies).
3. Propose target architecture slice for current task only.
4. Plan incremental migration with rollback-safe steps.
5. Implement minimal code changes for the current slice.
6. Verify behavior and summarize residual risks.

Do not perform broad rewrites when a narrow slice is requested.

## 6) Project-Specific Guardrails

- Preserve gameplay behavior unless user asks for behavior change.
- Prefer editing under `Assets/Scripts` and avoid generated Unity folders (`Library`, `Temp`, `Logs`, `obj`).
- Do not introduce runtime-wide singleton lookups if avoidable.
- Keep additions type-safe where possible; avoid new stringly-typed dispatch unless necessary for compatibility.
- If adding skill-like gameplay content, keep runtime core unchanged and add data/config first.
- Keep old `DesignerTables` and `DesignerScripts` compatible until an accepted OpenSpec change retires them.
- Treat the intended product as a top-down shooting game framework, not just the current prototype.
- Prefer authoring schema + validator + adapter slices over manager-loop rewrites.

## 7) Output Contract

For substantial requests, output sections in this order:

1. `Architecture Drivers`
2. `OpenSpec`
3. `Current vs Target`
4. `Change Plan`
5. `Implemented Changes`
6. `Verification`
7. `Risks / Next Slice`

For small requests, return only `Implemented Changes` and `Verification`.

## 8) Templates

Use:

- `references/request-template.md` to structure user intent.
- `references/review-template.md` to structure ABSD review output.
- `references/openspec-change-template.md` to structure OpenSpec change setup.
- `references/reverse-analysis-template.md` to structure code-to-requirements analysis.

