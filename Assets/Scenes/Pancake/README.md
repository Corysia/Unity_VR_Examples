# Pancake

- [Pancake](#pancake)
  - [Description](#description)
  - [Concept](#concept)
    - [Not Yet Supported](#not-yet-supported)
  - [Building](#building)
    - [Windows](#windows)
    - [Mac](#mac)

## Description

A pancake is a flat cake with a thick, usually solid, bottom.
The bottom of a pancake is called a *flap*.

*Pancake Mode* is  a term used to describe a VR game that is played in regular Desktop mode.
A few notable games support this, such as [The Forest](https://endnightgames.com/) and [Elite: Dangerous](https://www.elitedangerous.com/)

## Concept

When the application starts, it should detect whether or not a VR headset is connected.  If not, the application should disable the VR camera and enable the desktop camera.
If VR is detected, it should enable the VR camera and disable the desktop camera.  The Unity provided `SimpleCameraController` script is attached to the `DesktopCamera` to demonstrate how you might use a 1st Person Controller in this case.

### Not Yet Supported

When a VR headset is connected, the application should disable the regular camera and enable the VR camera.

## Building

### Windows

Normal Build & Run should be fine for both Desktop and Android

### Mac

To make a native Mac app, disable OpenXR in the Project Settings under XR Management.
