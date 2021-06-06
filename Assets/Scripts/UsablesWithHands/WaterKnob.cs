using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class WaterKnob : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 1;

  [Header("Information")]
  public float value;

  [Header("Initialization")]
  public UsableWithHand knob;
  public LineRenderer waterLine;
  public Spill spill;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Grab.canceled += HandleRelease;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Grab.canceled -= HandleRelease;
  }

  void Update () {
    if (knob.beingUsed) {
      Vector2 handControl = TheInputInstance.Input.Rafa.MoveHand.ReadValue<Vector2>();
      value = Mathf.Clamp(value + Mathf.Clamp(handControl.x, -Time.deltaTime, Time.deltaTime) * speed, 0, 1);
    }
    waterLine.endWidth = waterLine.startWidth = value * 0.08f;
    spill.enabled = value != 0;
  }

  public void HandleRelease (InputAction.CallbackContext ctx) {
    if (knob.beingUsed) {
      knob.StopUsing();
    }
  }
}
