# Walls

## Description

Prevent a player from "cheating" by walking through walls.

## Concept

The key to this tutorial is the "magic jigger" that Moardak taught me.  Each physics frame, the capsule is moved very slightly.  This causes Unity to test for collisions.  Without this, characters may not be able to thumbstick through walls, but they can physically step around within their guardian/playspace and bypass collisions.

### Notes

#### Character Controller

- Character Controller Y value should be 1.
- 0.5 feels very large for the radius of my body, so I typically set it to 0.2.
