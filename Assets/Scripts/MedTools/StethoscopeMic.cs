using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StethoscopeMic : MonoBehaviour {
  public static event System.Action<StethoscopeMic> onStatusChange;
  public static event System.Action<ClinicalSign> onSignLost;
  public static event System.Action<ClinicalSign> onSignFound;

  [Header("Information")]
  public StethoSign currentSign;
  public bool isGrabbed;

  [Header("Initialization")]
  public Grabbable grabbable;

  void OnEnable () {
    grabbable.onGrabbed += HandleGrab; grabbable.onDropped += HandleDrop;
  }

  void OnDisable () {
    grabbable.onGrabbed -= HandleGrab; grabbable.onDropped -= HandleDrop;
  }

  void OnTriggerStay2D (Collider2D c) {
    StethoSign sign = c.GetComponent<StethoSign>();
    if (!sign) return;
    onSignFound?.Invoke(sign.pattern);
    if (currentSign != sign) {
      currentSign = sign;
      onStatusChange?.Invoke(this);
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    StethoSign sign = c.GetComponent<StethoSign>();
    if (!sign) return;
    onSignLost?.Invoke(sign.pattern);
    if (sign == currentSign) {
      currentSign = null;
      onStatusChange?.Invoke(this);
    }
  }

  public void HandleGrab (GrabbingHand hand) {
    isGrabbed = true; onStatusChange?.Invoke(this);
  }

  public void HandleDrop () {
    isGrabbed = false; onStatusChange?.Invoke(this);
  }
}
