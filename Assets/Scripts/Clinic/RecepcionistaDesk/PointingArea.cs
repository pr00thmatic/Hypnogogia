using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointingArea : MonoBehaviour {
  [Header("Information")]
  public bool isPointing;

  void OnTriggerStay2D (Collider2D c) {
    if (c.GetComponentInParent<RafaPointingArm>()) {
      isPointing = true;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (c.GetComponentInParent<RafaPointingArm>()) {
      isPointing = false;
    }
  }
}
