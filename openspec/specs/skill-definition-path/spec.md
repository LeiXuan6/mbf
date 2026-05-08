# Skill Definition Path Specification

## Purpose

Capture the currently implemented pilot path for moving skill authoring from hard-coded C# tables toward data-driven definitions.

## Requirements

### Requirement: Resource-Based Skill Definitions

The runtime SHALL load pilot skill definitions from `Resources/GameData/SkillDefs`.

#### Scenario: Bulk load skill definitions

- **GIVEN** JSON skill definition files exist under `Assets/Resources/GameData/SkillDefs`
- **WHEN** `GameManager` initializes the main character
- **THEN** `SkillDefLoader.LoadAllDefsFromFolder("GameData/SkillDefs")` loads available text assets

### Requirement: Skill Definition Adaptation

The runtime SHALL adapt a valid skill definition into the existing `SkillModel` type.

#### Scenario: Valid skill definition

- **GIVEN** a skill definition has `id` and `timelineId`
- **AND** `timelineId` exists in `DesingerTables.Timeline.data`
- **WHEN** the definition is converted
- **THEN** `SkillDefLoader.ToSkillModel` returns a `SkillModel`
- **AND** the model uses the referenced existing timeline

### Requirement: Auto-Learn Pilot Skills

The runtime SHALL teach auto-learn skill definitions to the main actor during startup.

#### Scenario: Auto-learn enabled

- **GIVEN** a loaded skill definition has `autoLearn` set to true
- **WHEN** startup registration succeeds
- **THEN** the main actor learns the registered skill

### Requirement: New Fire 5 Pilot

The repository SHALL include a pilot `new_fire_5` skill that proves a minimal config-plus-adapter path.

#### Scenario: Fixed damage pilot

- **GIVEN** `new_fire_5` is loaded and learned
- **WHEN** the player casts it
- **THEN** it uses the `skill_new_fire_5` timeline
- **AND** fires the `fixed5` bullet model
- **AND** bullet hits use fixed 5 direct damage
