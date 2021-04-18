using UnityEngine;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class RafaMetarigTransform : MonoBehaviour {
  [Header("Configuration")]
  public bool followCommands = true;

  [Header("Initialization")]
  public PositionConstraint animationPosition;
  public RotationConstraint animationRotation;
  public PositionConstraint commandsPosition;
  public RotationConstraint commandsRotation;

  void Update () {
    if (followCommands) {
      commandsPosition.enabled = commandsRotation.enabled = true;
      animationPosition.enabled = animationRotation.enabled = false;
    } else {
      commandsPosition.enabled = commandsRotation.enabled = false;
      animationPosition.enabled = animationRotation.enabled = true;
    }
  }
}
