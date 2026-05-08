# Project Agent Rules

This repository is a Unity prototype that is being migrated toward a top-down shooting game framework. Treat existing gameplay code as reverse-engineering material and compatibility surface, not as the final architecture.

## Source of Truth

- OpenSpec owns requirements, current system facts, proposed changes, and accepted deltas.
- Read `openspec/project.md` and relevant `openspec/specs/*/spec.md` before planning a meaningful change.
- For non-trivial feature work, create or update `openspec/changes/<change-id>/` before editing runtime code.
- Do not silently rewrite historical facts. Supersede changed facts through an OpenSpec change.

## Standing Project Rules

- Preserve current prototype behavior unless the OpenSpec change explicitly says behavior may change.
- Keep Unity generated folders and build output out of normal edits: `Library`, `Temp`, `Logs`, `obj`, and `Game`.
- Prefer narrow changes under `Assets/Scripts`, `Assets/Resources/GameData`, `docs`, `openspec`, or `codex-absd-refactor-skill`.
- Keep current `DesignerTables` compatibility while migration is in progress.
- Avoid adding new scene-wide singleton lookups unless a change specifically budgets for architecture debt.
- Prefer typed adapters and schema validation over expanding stringly-typed dispatch.

## OpenSpec Workflow

Use this split:

- `openspec/specs/`: current truth about implemented behavior.
- `openspec/changes/`: proposed or in-progress changes.
- `AGENTS.md`: standing collaboration and safety rules.
- `codex-absd-refactor-skill/`: reusable execution workflow and templates.

For a substantial change:

1. Identify affected capability specs.
2. Create a change folder with `proposal.md`, `design.md` when architecture matters, `tasks.md`, and delta specs.
3. Implement only after the requirement delta is clear.
4. Mark tasks complete as work is verified.
5. Archive the change only after implementation and validation are accepted.

## Validation Expectations

- Unity version: `2022.3.62f3`.
- If Unity cannot be run from the current environment, state that clearly and provide manual editor checks.
- For documentation-only changes, verify by reading the created files and checking `git status`.
