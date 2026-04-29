# Skill Architecture Spec v0.1

## 1. Goal

Build a stable architecture path for this repository so that new gameplay skills can be added with minimal runtime changes and predictable quality.

Primary outcome:
- For most new skills, edit data/config first, not core runtime loops.

## 2. Scope

In scope:
- `Assets/Scripts` combat pipeline: Skill, Timeline, Buff, Bullet, AoE, Damage.
- ABSD-based refactor planning and incremental implementation.

Out of scope (v0.1):
- Full rewrite of managers.
- Large rendering or animation-system redesign.

## 3. Architecture Drivers

Priority order:
1. Extensibility
2. Maintainability
3. Testability
4. Performance (while preserving behavior)

Hard rule:
- Normal skill additions must not require editing core runtime dispatch loops.

## 4. Quality Attribute Scenarios

1. Add a forward-shot skill with fixed damage.
Expected:
- Implement mostly by configuration and a bounded adapter.

2. Add a timed AoE skill with enter/tick/remove effects.
Expected:
- Reuse existing event model, avoid core loop rewrite.

3. Modify one skill behavior without affecting unrelated skills.
Expected:
- Localized changes and low regression risk.

## 5. Current Architecture Summary

Observed strengths:
- Existing conceptual split around `Model / Obj / Info`.
- Rich extension hooks for Buff/Bullet/AoE/Timeline.

Observed risks:
- Global coupling through scene-wide lookups.
- String-based callback registration without compile-time safety.
- Runtime scanning patterns that may not scale.

## 6. Target Slice (v0.1)

Introduce a minimal skill-definition layer and adapter path:
- Skill definition file(s) for new skills.
- Adapter that maps definition to existing `SkillModel/TimelineModel`.
- No breaking change to old `DesignerTables` at this stage.

## 7. Migration Strategy

Phase 1:
- Add ABSD baseline docs and first migration slice plan.

Phase 2:
- Add one end-to-end pilot skill (`new_fire_5`) through config + adapter.

Phase 3:
- Validate behavior parity and document regressions.

Phase 4:
- Expand to more skills and gradually reduce direct table coupling.

## 8. Definition of Done (v0.1)

- Baseline architecture spec exists in repo.
- First migration slice is concretely planned with acceptance checks.
- Team can execute next step without redefining architecture intent.

