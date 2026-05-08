## ADDED Requirements

### Requirement: Framework-Authored Gameplay Content

The future framework SHALL allow top-down shooting gameplay content to be authored through validated data and framework-facing tools before requiring runtime code changes.

#### Scenario: Add simple skill from authored data

- **GIVEN** a designer defines a simple forward-shot skill in an authoring schema
- **WHEN** the project loads authored gameplay content
- **THEN** the skill is validated
- **AND** adapted into runtime models
- **AND** no manager loop changes are required

### Requirement: Runtime Compatibility During Migration

The future framework SHALL preserve compatibility with current runtime model types while authoring schemas are introduced.

#### Scenario: Adapter-backed runtime

- **GIVEN** authored content passes validation
- **WHEN** gameplay starts
- **THEN** adapters produce existing model types such as `SkillModel`, `TimelineModel`, `BulletModel`, or `AoeModel`
- **AND** existing managers continue to execute them

### Requirement: Source-Aware Validation

The future framework SHALL report invalid authored content with enough source context to fix it.

#### Scenario: Missing timeline reference

- **GIVEN** an authored skill references a missing timeline
- **WHEN** content validation runs
- **THEN** validation reports the skill id
- **AND** the source filename
- **AND** the missing timeline id
- **AND** startup does not crash

### Requirement: Framework Content Inventory

The future framework SHALL expose an inventory of loaded authored content and validation results.

#### Scenario: Inspect loaded content

- **GIVEN** authored maps, units, skills, projectiles, or effects are present
- **WHEN** the framework content inventory is opened
- **THEN** the user can see which content loaded
- **AND** which content failed validation
- **AND** the runtime ids produced by adapters

### Requirement: Top-Down Domain Boundaries

The future framework SHALL treat maps, units, timelines, skills, projectiles, AoE, effects, and combat policies as distinct authoring domains.

#### Scenario: Change projectile behavior

- **GIVEN** a projectile behavior is modified
- **WHEN** the authored projectile is validated and adapted
- **THEN** unrelated map, unit, and skill definitions are not modified unless explicitly referenced
