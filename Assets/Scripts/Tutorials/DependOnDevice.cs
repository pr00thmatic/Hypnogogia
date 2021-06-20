using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DependOnDevice : MonoBehaviour {
  public static string lastOne = "keyboard";

  void OnEnable () {
    transform.Find("gamepad").gameObject.SetActive(lastOne == "gamepad");
    transform.Find("keyboard").gameObject.SetActive(lastOne == "keyboard");
  }

  void Update () {
    if (TheInputInstance.Input.Rafa.MouseHandDetector.ReadValue<Vector2>().magnitude != 0) {
      lastOne = "keyboard";
      transform.Find("gamepad").gameObject.SetActive(false);
      transform.Find("keyboard").gameObject.SetActive(true);
    } else if (TheInputInstance.Input.Rafa.JoystickHandDetector.ReadValue<Vector2>().magnitude != 0) {
      lastOne = "gamepad";
      transform.Find("gamepad").gameObject.SetActive(true);
      transform.Find("keyboard").gameObject.SetActive(false);
    }
  }
}
