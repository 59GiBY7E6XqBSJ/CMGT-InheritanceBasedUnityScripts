# CMGT-InheritanceBasedUnityScripts
A collection of useful Unity scripts I am using in my Unity games.

## Requirements

### Unity

- Unity 2021.3.2f1+

## Scripts

### Player & Movement

- Player.cs - The main player class including all of the parameters and references to the sub classes, attatch to the main player object.
- PlayerControls.cs - The main movement class, attatch to the main player object.
- MouseRotate.cs - The look around script, attatch to the main camera object.

### Triggers

- Trigger.cs - The base class for various triggers, do not use as a behaviour script.
- AnimationTrigger.cs - The base class for the animation type of trigger, do not use as a behaviour script.
- PlayAudio.cs - Will play the given audio upon being triggered, attach to the trigger box.
- PlayAnimation.cs - Will play the given animation upon being triggered, attach to the trigger box.
- ChangeScene.cs - Will asynchronously change the scene upon being triggered, attach to the trigger box.

### Scripted

- ScriptedScene.cs - The base class for various scripted objects, do not use as a behaviour script.

### NPC

- NPC.cs - The base class for a NPC object, do not use as a behaviour script.

![Screenshot](https://i.imgur.com/14kpcm4.png)

### UI

- Tooltip.cs - The tooltip class with various usage parameters, attach to the tooltip trigger object.

![Screenshot](https://i.imgur.com/i2XE0RR.png)

### Example files

- Robot.cs - An example file of the NPC class usage.
- Prologue.cs - An example file of the ScriptedScene class usage.
