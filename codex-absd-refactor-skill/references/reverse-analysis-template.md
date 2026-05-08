# Reverse Analysis Template

Use this when deriving requirements from existing code.

## Lifecycle Lens

- Problem definition: why this framework exists and what scope it owns.
- Feasibility: technical, cost, operation, legal/policy, schedule, and migration risk.
- Requirements analysis: functional requirements, non-functional requirements, and domain rules.
- High-level design: subsystem/module decomposition and architecture boundaries.
- Detailed design: internal flows, interfaces, states, validation, and exceptions.
- Implementation: code/config/data/test artifacts.
- Testing: unit, integration, system, performance, safety, and regression checks.
- Deployment/maintenance/retirement: release, operations, evolution, and safe removal.

Keep "what" separate from "how":

- Put implemented or desired behavior in OpenSpec requirements.
- Put decomposition in design notes.
- Put internal flows and algorithms in detailed design.

## Code Evidence

- Entry points:
- Runtime loops:
- Data tables:
- Adapters/loaders:
- Scene or prefab dependencies:

## Current Facts

Facts that are implemented today and can become `openspec/specs` requirements.

- Fact:
- Evidence:
- Scenario:

## Target Requirements

Desired future behavior that should become `openspec/changes/<change-id>/specs` deltas.

- Requirement:
- Driver:
- Migration slice:

## Open Questions

- Question:
- Why it matters:
- Suggested default:

## Risks

- Compatibility:
- Validation:
- Tooling:
- Runtime behavior:
