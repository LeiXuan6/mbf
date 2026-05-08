# Prototype Runtime Specification

## Purpose

Capture the current implemented gameplay runtime so future shooting game framework work can preserve or intentionally replace prototype behavior.

## Requirements

### Requirement: Scene Bootstrap

The prototype SHALL bootstrap gameplay from `GameManager` by creating a random map, creating the main actor, wiring camera/UI references, teaching baseline skills, and starting skill-definition registration.

#### Scenario: Main actor creation

- **GIVEN** the `GameMain` scene starts
- **WHEN** `GameManager.Start` runs
- **THEN** a main character is created from character prefabs
- **AND** `PlayerController` is attached
- **AND** the camera follows the main character

### Requirement: Timeline-Driven Skill Execution

The prototype SHALL execute skills through `TimelineModel` and `TimelineObj` rather than immediate direct skill effects.

#### Scenario: Skill cast creates timeline

- **GIVEN** a character has learned a skill
- **AND** the character has enough required resources
- **WHEN** `ChaState.CastSkill` is called with that skill id
- **THEN** a `TimelineObj` is created from the skill model
- **AND** the timeline is submitted to `TimelineManager`
- **AND** skill cost is deducted on successful timeline creation

### Requirement: Manager-Owned Combat Loops

The prototype SHALL process bullets, AoE objects, timelines, and damage through dedicated manager loops.

#### Scenario: Runtime processing

- **GIVEN** bullets, AoE objects, timelines, or queued damage exist in the scene
- **WHEN** Unity fixed updates run
- **THEN** `BulletManager`, `AoeManager`, `TimelineManager`, and `DamageManager` process their respective objects

### Requirement: Hard-Coded Table Compatibility

The prototype SHALL keep existing `DesingerTables` and `DesignerScripts` data available during migration.

#### Scenario: Existing skills remain available

- **GIVEN** the player is initialized
- **WHEN** baseline skills are learned from `DesingerTables.Skill.data`
- **THEN** existing skills such as `fire`, `roll`, `grenade`, and `teleportBullet` remain castable if their runtime requirements are met

### Requirement: Top-Down Movement Model

The prototype SHALL represent gameplay movement mainly on the X/Z plane with map collision mediated by `MapInfo` and `UnitMove`.

#### Scenario: Unit movement correction

- **GIVEN** a unit requests movement through `UnitMove.MoveBy`
- **WHEN** fixed update applies the movement
- **THEN** the target position is corrected by `SceneVariants.map.FixTargetPosition`
- **AND** obstacle state is recorded for non-smooth movement
