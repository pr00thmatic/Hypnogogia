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

  void OnEnable () {
    TheInputInstance.Input.Rafa.Interact.performed += HandleInteraction;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Interact.performed -= HandleInteraction;
  }

  public void HandleInteraction (InputAction.CallbackContext ctx) {
    if (!current) return;
    if (current.climbedUp) {
      animation = StartCoroutine(_ClimbDown());
    } else {
      animation = StartCoroutine(_ClimbUp());
    }
  }

  public void ClimbDown () { StartCoroutine(_ClimbDown()); }
  IEnumerator _ClimbDown () {
    motion.blockedByLadder = true;
    animator.SetTrigger("climb down"); current.climbedUp = false;
    yield return StartCoroutine(_ToStart());
    yield return new WaitForSeconds(0.5f);
    motion.blockedByLadder = false;
    animation = null;
  }

  public void ClimbUp () { StartCoroutine(_ClimbUp()); }
  IEnumerator _ClimbUp () {
    motion.blockedByLadder = true;
    animator.SetTrigger("climb up"); current.climbedUp = true;
    yield return StartCoroutine(_ToStart());
    yield return StartCoroutine(_ToEnd());
    motion.blockedByLadder = current.blocksMotionWhileUp;
    animation = null;
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
