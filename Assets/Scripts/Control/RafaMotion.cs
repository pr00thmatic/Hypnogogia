using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class RafaMotion : MonoBehaviour {
  [Header("Information")]
  public int orientation = 1;
  public float speed = 4;
  public bool blockedByLadder = false;

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
    }

    rotationTarget.transform.rotation =
      Quaternion.Euler(Utils.SetY(rotationTarget.transform.rotation.eulerAngles, orientation < 0? 180: 0));

    if (!blockedByLadder) {
      animator.SetFloat("speed", Mathf.Abs(walk.x));
      transform.position += Vector3.right * speed * Time.deltaTime * walk.x;
    } else {
      animator.SetFloat("speed", 0);
    }
  }

  public void HandleDuck (InputAction.CallbackContext ctx) {
    if (blockedByLadder) return;
    animator.SetBool("ducking", !animator.GetBool("ducking"));
  }
}
