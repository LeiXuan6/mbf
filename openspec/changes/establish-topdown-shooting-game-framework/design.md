# Design: Top-Down Shooting Game Framework Direction

## Reverse-Engineered Domain Model

The prototype already implies these editor concepts:

- Scene root and runtime services: `GameManager`, manager components, UI, camera, object layer.
- Map model: `MapInfo`, `GridInfo`, terrain prefabs, passability, random map generation.
- Unit model: character prefab, base properties, tags, side, view prefab, animation map, bind points.
- Ability model: skill id, resource cost/condition, timeline reference, passive learn-time buffs.
- Timeline model: timed nodes, event ids, event parameters, duration, charge loop.
- Projectile model: bullet prefab, move type, hit policy, hit callback, removal callback, target/tween functions.
- AoE model: prefab, radius, duration, tick policy, enter/leave callbacks, tween.
- Effect model: bind-point effects, sight effects, temporary visual objects.
- Combat model: damage types, damage tags, buff hooks, resource modification.

## Target Architecture Slice

The shooting game framework should introduce an authoring layer before replacing runtime loops:

1. Authoring schemas describe maps, units, skills, timelines, projectiles, AoE, damage policies, and effects.
2. Validators check schema references and emit source-aware errors.
3. Adapters convert authoring data into current runtime models.
4. Runtime managers continue to execute existing model types until a later migration explicitly replaces them.

## Boundary Decisions

- OpenSpec captures capability requirements and migration facts.
- `AGENTS.md` captures standing repository rules.
- The Codex skill captures the repeatable workflow for reverse analysis, OpenSpec change work, ABSD slicing, implementation, and verification.
- Do not move all hard-coded tables at once. Migrate one capability slice at a time.

## Initial Slices

1. Skill schema hardening: source filenames, duplicate detection, timeline existence, clear invalid reasons.
2. Timeline authoring schema: allow timeline nodes to be declared outside C# for simple existing event types.
3. Projectile/damage schema: allow fixed and scaled damage policies without new callback methods.
4. Editor inventory surface: list loaded authored content and validation results.
