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
  public PositionConstraint commandsPosition;

  void Update () {
    if (followCommands) {
      commandsPosition.enabled = true;
      animationPosition.enabled = false;
    } else {
      commandsPosition.enabled = false;
      animationPosition.enabled = true;
    }
  }
}
