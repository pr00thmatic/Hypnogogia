using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextuallyGrabbable : MonoBehaviour {
  [Header("Information")]
  public GrabbingPointingArm pointing;

  [Header("Initialization")]
  public Animator animator;

  void OnTriggerStay2D (Collider2D c) {
    GrabbingPointingArm found = c.GetComponentInParent<GrabbingPointingArm>();
    if (!found) return;
    pointing = found;
    if (!found.highlighted) { Highlight(true); return; }
    if (Vector3.Distance(pointing.grabAnchor.position, transform.position) < pointing.DistanceToHighlighted) Highlight(true);
  }

  void OnTriggerExit2D (Collider2D c) {
    GrabbingPointingArm found = c.GetComponentInParent<GrabbingPointingArm>();
    if (!found) return;
    if (found != pointing) return;

    Highlight(false);
    if (pointing.highlighted == this) pointing.highlighted = null;
    pointing = null;
  }

  public void Highlight (bool value) {
    animator.SetBool("is highlighted", value);
  }
}
