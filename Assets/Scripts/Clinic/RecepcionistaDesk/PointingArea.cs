using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointingArea : MonoBehaviour {
  // [Header("Information")]
  public bool IsPointing { get => talkIndicator.gameObject.activeSelf; set => talkIndicator.gameObject.SetActive(value); }

  [Header("Initialization")]
  public GameObject talkIndicator;

  void OnEnable () { IsPointing = false; }
  void OnDisable () { IsPointing = false; }

  void OnTriggerStay2D (Collider2D c) {
    if (c.GetComponentInParent<RafaPointingArm>()) {
      IsPointing = true;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (c.GetComponentInParent<RafaPointingArm>()) {
      IsPointing = false;
    }
  }
}
