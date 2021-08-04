using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaPointingArmJoystick : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 4;

  [Header("Initialization")]
  public RafaPointingArm arm;

  void Update () {
    Vector2 input = TheInputInstance.Rafa.MoveHand.ReadValue<Vector2>();
    Vector3 desiredPosition = arm.fingerTip.position + new Vector3(input.x, input.y, 0) * Time.deltaTime * speed;
    arm.MoveTo(desiredPosition);
  }
}
