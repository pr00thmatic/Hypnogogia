using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class LadderUser : MonoBehaviour {
  [Header("Configuration")]
  public float timeToStart;
  public float timeToClimb;

  [Header("Information")]
  public Ladder current;
  public new Coroutine animation;

  [Header("Initialization")]
  public Transform root;
  public Animator animator;
  public RafaMotion motion;
  public Rigidbody2D body;

  void OnEnable () { TheInputInstance.Input.Rafa.Interact.performed += HandleInteraction; }
  void OnDisable () { TheInputInstance.Input.Rafa.Interact.performed -= HandleInteraction; }

  public void HandleInteraction (InputAction.CallbackContext ctx) {
    if (!current) return;
    if (current.climbedUp) {
      animation = StartCoroutine(_ClimbTo("climb down"));
    } else {
      animation = StartCoroutine(_ClimbTo("climb up"));
    }
  }

  public void ClimbDown () { StartCoroutine(_ClimbTo("climb down")); }
  public void ClimbUp () { StartCoroutine(_ClimbTo("climb up")); }
  IEnumerator _ClimbTo(string triggerName) {
    bool up = triggerName == "climb up";
    motion.blockedByLadder = true;
    animator.SetTrigger(triggerName); current.climbedUp = up;
    body.isKinematic = true;
    if (up) {
      yield return StartCoroutine(_ToStart());
      yield return StartCoroutine(_ToEnd());
    } else {
      yield return StartCoroutine(_ToStart());
      yield return new WaitForSeconds(0.5f);
    }
    motion.blockedByLadder = up && current.blocksMotionWhileUp;
    animation = null;
    if (!current.blocksMotionWhileUp) {
      body.isKinematic = false;
    }
  }

  IEnumerator _ToStart () {
    float elapsed = 0;
    Vector3 initial = root.position;
    while (elapsed < timeToStart) {
      elapsed += Time.deltaTime;
      root.position = Vector3.Lerp(initial, current.startPose.position, elapsed / timeToStart);
      yield return null;
    }
  }

  IEnumerator _ToEnd () {
    float elapsed = 0;
    Vector3 initial = root.position;
    while (elapsed < timeToClimb) {
      elapsed += Time.deltaTime;
      root.position = Vector3.Lerp(initial, current.endPose.position, elapsed / timeToClimb);
      yield return null;
    }
  }
}
