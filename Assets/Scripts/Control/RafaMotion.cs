using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class RafaMotion : MonoBehaviour {
  [Header("Information")]
  public int orientation = 1;

  [Header("Initialization")]
  public Animator animator;
  public Transform rotationTarget;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Duck.performed += HandleDuck;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Duck.performed -= HandleDuck;
  }

  void Update () {
    Vector2 walk = TheInputInstance.Input.Rafa.Walk.ReadValue<Vector2>();

    if (walk.x != 0) {
      orientation = (int) Mathf.Sign(walk.x);
    }//  else {
    //   animator.SetFloat("offset", Random.Range(0, 1f));
    // }

    animator.SetFloat("speed", Mathf.Abs(walk.x));
    rotationTarget.transform.rotation =
      Quaternion.Euler(Utils.SetY(rotationTarget.transform.rotation.eulerAngles, orientation < 0? 180: 0));
  }

  public void HandleDuck (InputAction.CallbackContext ctx) {
      animator.SetBool("ducking", !animator.GetBool("ducking"));
  }
}
