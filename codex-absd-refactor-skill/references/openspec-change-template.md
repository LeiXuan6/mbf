# OpenSpec Change Template

## Change ID

Use kebab-case and make it action-oriented.

Examples:

- `add-skill-schema-validation`
- `introduce-timeline-authoring`
- `extract-editor-content-inventory`

## Required Files

```text
openspec/changes/<change-id>/
├── proposal.md
├── tasks.md
├── design.md
└── specs/
    └── <capability>/
        └── spec.md
```

`design.md` is optional for small changes, but should be present for architecture or migration work.

## proposal.md Shape

```markdown
# Change: <Human Title>

## Why

## What

## Impact
```

## tasks.md Shape

```markdown
# Tasks

- [ ] Update specs
- [ ] Implement slice
- [ ] Verify behavior
```

## Delta Spec Shape

```markdown
## ADDED Requirements

### Requirement: <Name>
The system SHALL ...

#### Scenario: <Name>
- **GIVEN** ...
- **WHEN** ...
- **THEN** ...
```

Use `MODIFIED`, `REMOVED`, or `RENAMED` requirements only when changing existing current truth.
