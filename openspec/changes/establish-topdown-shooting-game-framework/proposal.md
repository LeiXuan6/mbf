# Change: Establish Top-Down Shooting Game Framework Direction

## Why

The current repository is a working top-down shooter prototype, but future work is expected to turn it into a reusable top-down shooting game framework. The code already contains useful concepts: timeline events, skills, bullets, AoE, damage, map grids, prefabs, and runtime managers. These concepts need to be captured as requirements before large refactors start.

## What

- Define the target shooting-game-framework capabilities inferred from the prototype.
- Establish a migration direction from hard-coded gameplay tables to editor-authored, validated data.
- Preserve prototype runtime behavior while adding framework boundaries.
- Clarify the first implementation slices that should follow this documentation change.

## Impact

- Adds OpenSpec deltas for future shooting game framework capabilities.
- Does not change Unity runtime code yet.
- Gives future Codex work a stable requirements surface before implementation.
