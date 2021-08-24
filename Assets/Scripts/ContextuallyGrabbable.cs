using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextuallyGrabbable : MonoBehaviour {
  [Header("Information")]
  public GrabbingPointingArm pointing;
  public Vector3 localPoint;
  public bool IsGrabbed { get => grabbingArm; }
  public GrabbingPointingArm grabbingArm;
  public bool CanBeReleased { get => area; }
  public ReleasableArea area;

  [Header("Initialization")]
  public Animator animator;
  public new Collider2D collider;
  public Rigidbody2D body;

  void Update () {
    if (grabbingArm) {
      transform.position = grabbingArm.grabAnchor.TransformPoint(localPoint);
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    ReleasableArea area = c.GetComponentInParent<ReleasableArea>();
    if (area && !area.blocked) {
      this.area = area; return;
    }
    GrabbingPointingArm found = c.GetComponentInParent<GrabbingPointingArm>();
    if (!found) return;
    pointing = found;
    if (!found.highlighted) { Highlight(true); return; }
    if (Vector3.Distance(pointing.grabAnchor.position, transform.position) < pointing.DistanceToHighlighted) Highlight(true);
  }

  void OnTriggerExit2D (Collider2D c) {
    ReleasableArea foundArea = c.GetComponentInParent<ReleasableArea>();
    if (foundArea) {
      area = null;
      return;
    }
    GrabbingPointingArm found = c.GetComponentInParent<GrabbingPointingArm>();
    if (!found) return;
    if (found != pointing) return;

    Highlight(false);
    pointing = null;
  }

  public void Highlight (bool value) {
    animator.SetBool("is highlighted", value);
    if (pointing && value) pointing.highlighted = this;
    if (!value && pointing.highlighted == this) pointing.highlighted = null;
  }

  public void AnchorTo (GrabbingPointingArm arm) {
    grabbingArm = arm;
    // localPoint = grabbingArm.grabAnchor.InverseTransformPoint(transform.position);
    animator.SetBool("is grabbed", true);
    collider.isTrigger = true;
    body.isKinematic = true;
  }

  public void Unanchor () {
    animator.SetBool("is grabbed", false);
    animator.SetBool("is highlighted", false);
    grabbingArm = null;
    localPoint = Vector3.zero;
    collider.isTrigger = false;
    body.isKinematic = false;
    if (area) area.TriggerRelease(this);
  }
}
