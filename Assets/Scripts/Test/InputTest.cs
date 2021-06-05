using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class InputTest : MonoBehaviour {
  [Header("Information")]
  public float test;
  public Vector2 test2;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Talk.performed += HandleTalk;
  }

  void Update () {
    test2 = TheInputInstance.Input.Rafa.Walk.ReadValue<Vector2>();
  }

  public void HandleTalk (InputAction.CallbackContext ctx) {
    test = Time.time;
  }
}
