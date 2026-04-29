# Migration Slice 02: SkillDef Hardening

## Goal

Harden the new skill-definition path so scaling to more skills stays predictable.

## Focus

1. Validation hardening
- Required fields (`id`, `timelineId`)
- Timeline existence check
- Duplicate id reporting

2. Observability
- Clear startup logs for loaded/failed skill defs
- One-line summary: loaded count, failed count

3. Safety constraints
- Keep old `DesignerTables` path intact
- Do not change runtime manager loops

## Acceptance

1. Invalid skill def does not crash startup.
2. Invalid skill def is reported with filename and reason.
3. Valid skill defs are registered and optional `autoLearn` still works.

