using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class HandControl : MonoBehaviour {
  [Header("Configuration")]
  public float radius = 1;
  public bool invertHand = true;

  [Header("Initialization")]
  public Transform shoulder;
  public Transform arm1;
  public Transform motionTarget;
  public RafaMetarigTransform metaRig;
  public MonoBehaviour[] blockers;

  void OnEnable () {
    metaRig.followCommands = true;
    TheInputInstance.Input.Rafa.SwitchHand.performed += SwitchHand;
  }

  void OnDisable () {
    metaRig.followCommands = false;
    TheInputInstance.Input.Rafa.SwitchHand.performed -= SwitchHand;
  }

  public void MoveTo (Vector3 point) {
    foreach (MonoBehaviour blocker in blockers) {
      if ((blocker as IBlockHandMotion).BlockingHandMotion) return;
    }

    Vector3 d = point - shoulder.position;
    motionTarget.position = Vector3.ClampMagnitude(d, radius) + shoulder.position;
    motionTarget.rotation = arm1.rotation * Quaternion.Euler(0,0,90 * (invertHand? 1: -1));
  }

  public void SwitchHand (InputAction.CallbackContext ctx) {
    GetComponentInParent<RafaControls>().SwitchHand();
  }
}
