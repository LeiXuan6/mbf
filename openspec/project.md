# Project Context

## Purpose

This repository currently contains a Unity top-down shooter prototype. The intended direction is to evolve it into a reusable top-down shooting game framework where developers and designers can author maps, entities, skills, bullets, AoE effects, and scenario rules through data and framework tools rather than by editing runtime dispatch code.

## Current State

- Engine: Unity `2022.3.62f3`.
- Runtime code lives mainly in `Assets/Scripts`.
- Gameplay data currently mixes C# static tables, string-keyed callbacks, prefabs under `Resources`, and one pilot JSON skill definition.
- Current ABSD documents live under `docs/absd`.
- A repository-local Codex skill exists under `codex-absd-refactor-skill`.

## Target Direction

- OpenSpec records current facts, requirements, and proposed changes.
- `AGENTS.md` records stable project rules for AI agents and maintainers.
- Codex Skill records reusable execution workflow: reverse analysis, OpenSpec change preparation, ABSD slicing, implementation, and verification.
- The runtime should gradually move from hard-coded gameplay tables to validated authoring schemas and adapters.

## Architecture Drivers

1. Framework extensibility: new top-down shooting gameplay content should be authorable without changing manager loops.
2. Maintainability: current prototype concepts should be named, bounded, and migrated incrementally.
3. Testability: configuration and adapters should be verifiable without launching a full scene whenever possible.
4. Compatibility: existing prototype skills and scene behavior should remain usable during migration.
5. Observability: invalid content should fail with clear source filenames and reasons.

## Requirements Analysis Method

Use software lifecycle thinking when reverse-analyzing this prototype:

1. Problem definition: why the framework exists, what problem it solves, and what the boundary is.
2. Feasibility: whether the target slice is technically, economically, operationally, legally, and schedule feasible.
3. Requirements analysis: what the system must do. Separate functional requirements, non-functional requirements, and domain/business rules.
4. High-level design: how the system is decomposed into subsystems, modules, data boundaries, and runtime/editor-facing architecture.
5. Detailed design: how each module works internally, including flows, interfaces, state transitions, errors, and validation.
6. Implementation: code, configuration, data assets, tests, and build scripts.
7. Testing: functional, integration, system, performance, safety, and regression validation.
8. Deployment: release path, environments, rollback, and operational setup.
9. Maintenance: fixes, optimization, iteration, monitoring, and preventive refactors.
10. Retirement: migration, archiving, backup, and safe removal.

When producing requirements, do not mix requirement and design layers:

- Requirements answer "what the top-down shooting game framework shall provide".
- High-level design answers "how the framework is split".
- Detailed design answers "how a specific module or flow works".

For this repo, code-derived requirements should be classified as:

- Functional requirements: maps, units, skills, timelines, projectiles, AoE, combat, content inventory, validation, and runtime preview capabilities.
- Non-functional requirements: extensibility, maintainability, compatibility with the prototype, performance, observability, and testability.
- Domain rules: map passability, skill casting, resource cost/condition, timeline node execution, projectile hit policy, AoE lifecycle, damage tags, buff hooks, and content reference validation.

## Key Code Areas

- `Assets/Scripts/GameManager.cs`: scene bootstrap and object factories.
- `Assets/Scripts/Character/ChaState.cs`: character state, skill casting, buff lifecycle.
- `Assets/Scripts/TimelineManager.cs`: skill timeline execution.
- `Assets/Scripts/BulletManager.cs`: bullet movement and hit processing.
- `Assets/Scripts/AoeManager.cs`: AoE movement and enter/leave processing.
- `Assets/Scripts/DamageManager.cs`: damage pipeline.
- `Assets/Scripts/GameData/DesignerTables`: hard-coded gameplay tables.
- `Assets/Scripts/GameData/DesignerScripts`: string-keyed gameplay callbacks.
- `Assets/Scripts/GameData/SkillDefLoader.cs`: pilot JSON skill loader.
- `Assets/Resources/GameData/SkillDefs`: pilot skill definition data.

## Current Known Risks

- Many runtime extension points are string-keyed and fail late.
- `SceneVariants` and managers depend on scene-wide lookups.
- Some comments appear to be encoded inconsistently when read by tooling.
- The current skill definition path does not yet describe timelines, bullets, damage policies, or editor metadata.
