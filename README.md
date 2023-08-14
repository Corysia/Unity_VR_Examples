# Unity_VR_Examples

A collection of VR Examples

- [Unity\_VR\_Examples](#unity_vr_examples)
  - [Requirements](#requirements)
    - [Windows](#windows)
    - [Mac](#mac)
  - [Examples](#examples)
    - [Pancake](#pancake)
    - [Roomscale Fix](#roomscale-fix)
    - [Controller Button Press](#controller-button-press)
    - [Jump](#jump)

## Requirements

- Unity 2022.3.7f1 or later

### Windows

- One of: Oculus Quest, Rift, HTC Vive, Index

### Mac

- Oculus Quest

## Examples

### Pancake

This example shows how to configure a VR project work in normal desktop mode.  Whether to use a First Person of 3rd Person controller is not covered.  More information can be found [here](./Assets/Scenes/Pancake/README.md).

### Roomscale Fix

An example of how to stop players from being able to walk about within their play space and simply pass thru walls.  Try out the Walls scene.  More information can be found [here](./Assets/Scenes/Walls/README.md).

### Controller Button Press

This example shows how to assign a custom key mapping to an object.  In this case it's a cube.  If the cube is held and the primary button on the controller is pressed, the cube will change color.  Only the button on the controller holding the object will activate the color change.  If the cube is dropped, the cube will not change color.  Try it out in the ControllerButtonPress scene.

### Jump

Demonstrate how to map a key to a button on the controller.  In this case, the A button on the controller will cause the player to jump.  The player will not jump if the A button is pressed while the player is in the air.  Currently, there is a bug where the player can infinitely jump when the app is first started.  Once the character has moved, the bug is no longer present.  Still working on this one...  Try it out in the Jump scene.  Note that unlike the Roomscale Fix example, this example uses the Capsule Collider rather than a Character Controller.  This is so physics can be applied to the player.