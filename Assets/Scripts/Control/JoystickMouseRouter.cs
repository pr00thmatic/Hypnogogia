using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JoystickMouseRouter : MonoBehaviour {
  [Header("Initialization")]
  public HandMouseFollow mouseControl;
  public JoystickHand joystickControl;

  void Update () {
    mouseControl.enabled = TheInputInstance.Input.Rafa.MouseHandDetector.ReadValue<Vector2>().magnitude != 0;
    joystickControl.enabled = TheInputInstance.Input.Rafa.JoystickHandDetector.ReadValue<Vector2>().magnitude != 0;
  }
}
