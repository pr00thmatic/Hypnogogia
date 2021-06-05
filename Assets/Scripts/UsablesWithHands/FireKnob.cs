using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FireKnob : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 1;
  public Vector2 angles = new Vector2(-168.12f, -23);

  // [Header("Information")]
  public float Value { get => fire.value; }

  [Header("Initialization")]
  public FirelyLightsController fire;
  public UsableWithHand knob;
  public Transform knobSprite;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Grab.canceled += HandleRelease;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Grab.canceled -= HandleRelease;
  }

  void Update () {
    if (knob.beingUsed) {
      Vector2 handControl = TheInputInstance.Input.Rafa.MoveHand.ReadValue<Vector2>();
      fire.value = Mathf.Clamp(fire.value + Mathf.Clamp(handControl.y, -Time.deltaTime, Time.deltaTime) * speed, 0, 1);
    }

    if (knobSprite) {
      knobSprite.rotation = Quaternion.Euler(0,0, Mathf.Lerp(angles.y, angles.x, fire.value));
    }
  }

  public void HandleRelease (InputAction.CallbackContext ctx) {
    if (knob.beingUsed) {
      knob.StopUsing();
    }
  }
}
