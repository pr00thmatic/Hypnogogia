using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class JoystickHand : MonoBehaviour {
  [Header("Configuration")]
  public float handSpeed = 2;

  [Header("Initialization")]
  public HandControl control;

  public void FixedUpdate () {
    Vector2 input = TheInputInstance.Input.Rafa.MoveHand.ReadValue<Vector2>();
    control.MoveTo(control.motionTarget.position + (input.x * Vector3.right + input.y * Vector3.up) * handSpeed * Time.deltaTime);
  }
}
