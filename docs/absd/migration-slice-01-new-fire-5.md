# Migration Slice 01: `new_fire_5`

## 1. Slice Goal

Deliver one minimal ABSD slice proving the path:
- Add a new skill `new_fire_5` (forward bullet, fixed 5 damage)
- Keep runtime core loops unchanged
- Prefer data/config + bounded adapter changes

## 2. Constraints

- Preserve current gameplay behavior for existing skills.
- Do not refactor `BulletManager`, `AoeManager`, `TimelineManager` in this slice.
- Keep changes inside a small, reviewable file set.

## 3. Planned Changes

1. Add minimal skill definition file
- Proposed location: `Assets/Scripts/GameData/SkillDefs/new_fire_5.json` (or yaml)
- Include only necessary fields:
  - skill id
  - timeline id/nodes
  - bullet spec
  - damage policy (fixed 5)

2. Add adapter/loader
- Read the new definition file.
- Convert to existing `SkillModel` + `TimelineModel`.
- Register into current runtime entry point without removing old table path.

3. Add fixed-damage bullet behavior path
- Reuse existing hit pipeline.
- Add bounded handler path for fixed damage = 5.
- Avoid broad callback-system redesign in this slice.

4. Bind for local test
- Ensure player can learn/cast `new_fire_5` for manual verification.

## 4. Acceptance Criteria

Functional:
1. Skill can be cast in game.
2. Bullet travels forward and hits valid target.
3. Damage applied is fixed at 5.

Architecture:
1. Existing skills still work unchanged.
2. Core runtime loops are untouched.
3. New skill path is documented and reusable.

## 5. Verification Plan

1. Launch scene and cast `new_fire_5` repeatedly.
2. Validate hit feedback and HP change on enemy.
3. Smoke test existing skills (`fire`, `roll`, `grenade`) for no regression.

## 6. Risks

1. Adapter mismatch with existing timeline assumptions.
2. String callback IDs still vulnerable to typo errors.
3. Debug visibility may be low without extra logs.

## 7. Exit Criteria

- Slice is complete when acceptance checks pass and file changes remain bounded.
- Next slice starts only after recording lessons learned in `docs/absd`.

