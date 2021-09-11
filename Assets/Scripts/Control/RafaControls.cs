using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaControls : MonoBehaviour {
  [Header("Information")]
  public int currentHand;
  public Transform CurrentHand { get => handControls.transform.GetChild(currentHand); }
  public Vector3 CurrentHandPosition { get => CurrentHand.position; }

  [Header("Initialization")]
  public GameObject handControls;
  public GameObject allControls;
  public RafaMotion motion;
  public Animator animator;

  void Awake () {
    ControlTaker.onControlRequested += HandleControlRequest;
    ControlTaker.onControlResumed += ResumeControl;
  }

  void OnDestroy () {
    if (!this) return;
    ControlTaker.onControlRequested -= HandleControlRequest;
    ControlTaker.onControlResumed -= ResumeControl;
  }

  void Start () {
    SetControlTo(currentHand, true);
  }

  public void SwitchHand () {
    SetControlTo(currentHand, false);
    currentHand = (currentHand + 1) % handControls.transform.childCount;
    SetControlTo(currentHand, true);
  }

  public void SetControlTo (int handIndex, bool enabled) {
    handControls.transform.GetChild(handIndex).gameObject.SetActive(enabled);
  }

  public void HandleControlRequest (ControlTaker requester) {
    TheAlwaysActiveGameObject.Instance.StartCoroutine(_HandleControlRequest(requester)); }
  IEnumerator _HandleControlRequest (ControlTaker requester) {
    animator.SetFloat("speed", 0);
    allControls.SetActive(false);
    if (requester.targetPosition) {
      while (Mathf.Abs(motion.motionTarget.position.x - requester.targetPosition.position.x) >= 0.01) {
        motion.UpdateOrientation(Mathf.Sign(requester.targetPosition.position.x - motion.motionTarget.position.x));
        animator.SetFloat("speed", 1);
        motion.motionTarget.position =
          Utils.SetX(motion.motionTarget.position, Mathf.MoveTowards(motion.motionTarget.position.x,
                                                                     requester.targetPosition.position.x,
                                                                     motion.speed * Time.deltaTime));
        yield return null;
      }
      motion.UpdateOrientation(Mathf.Sign(requester.targetPosition.position.x));
      animator.SetFloat("speed", 0);
    }
    if (requester.rafaAnimation != "") {
      animator.CrossFadeInFixedTime(requester.rafaAnimation, 0.15f);
    }
  }

  public void ResumeControl (ControlTaker requester) {
    allControls.SetActive(true);
    if (requester.rafaAnimation != "") {
      animator.CrossFadeInFixedTime("Idle", 0.15f);
    }
  }
}
