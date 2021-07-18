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
    allControls.SetActive(false);
  }

  public void ResumeControl (ControlTaker requester) {
    allControls.SetActive(true);
  }
}
