## MODIFIED Requirements

### Requirement: Resource-Based Skill Definitions

The runtime SHALL load pilot skill definitions from `Resources/GameData/SkillDefs`, and the future framework SHALL evolve this folder into a validated authoring source rather than a thin reference to hard-coded timelines.

#### Scenario: Bulk load skill definitions

- **GIVEN** JSON skill definition files exist under `Assets/Resources/GameData/SkillDefs`
- **WHEN** the project loads skill definitions
- **THEN** all files are parsed as authored content
- **AND** each valid definition is adapted into runtime-compatible skill data
- **AND** each invalid definition is reported with source context

## ADDED Requirements

### Requirement: Skill Authoring Expansion

The future skill authoring path SHALL support enough data to describe simple skills without adding new C# table entries.

#### Scenario: Simple fixed-damage projectile skill

- **GIVEN** an authored skill declares cost, input metadata, timeline nodes, projectile reference, and fixed damage policy
- **WHEN** validation succeeds
- **THEN** the runtime can register and cast the skill without adding a new entry to `DesingerTables.Skill`, `DesingerTables.Timeline`, or `DesingerTables.Bullet`
