# Agent Governance Specification

## Purpose

Define how repository knowledge is split between OpenSpec, standing agent rules, and reusable Codex skill workflows.

## Requirements

### Requirement: Knowledge Boundary

The project SHALL separate requirements, standing rules, and reusable execution workflows.

#### Scenario: Choosing the right knowledge location

- **GIVEN** a fact describes current or proposed product behavior
- **WHEN** it is documented
- **THEN** it belongs in `openspec/specs` or `openspec/changes`
- **AND** not only in chat history

#### Scenario: Standing project rule

- **GIVEN** an instruction should apply to most future agent work
- **WHEN** it is documented
- **THEN** it belongs in `AGENTS.md`

#### Scenario: Reusable execution flow

- **GIVEN** a repeatable procedure helps agents perform work
- **WHEN** it is documented
- **THEN** it belongs in the Codex skill under `codex-absd-refactor-skill`

### Requirement: Change-First Implementation

The project SHALL use OpenSpec changes before substantial runtime or shooting game framework implementation.

#### Scenario: Non-trivial feature request

- **GIVEN** a requested change affects gameplay behavior, shooting game framework architecture, data schemas, or migration direction
- **WHEN** an agent begins work
- **THEN** the agent creates or updates a change under `openspec/changes`
- **AND** implementation follows the accepted change scope
