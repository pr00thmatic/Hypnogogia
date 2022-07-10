using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class GrabbingHand : MonoBehaviour {
  [Header("Configuration")]
  public int grabbedSortingOrder = -1;

  [Header("Information")]
  public Grabbable currentlyGrabbed;
  public Vector3 Center { get => (Vector3) c.offset + transform.position; }
  public Transform visualHand;

  [Header("Initialization")]
  public RafaMotion motion;
  public Transform movingHand;
  public CircleCollider2D c;
  public UserHand user;
  public SelectedHand hand;
  public ParentConstraint forceFollow;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Grab.performed += HandleGrab;
    visualHand = this.forceFollow.GetSource(0).sourceTransform;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Grab.performed -= HandleGrab;
  }

  void LateUpdate () {
    if (!currentlyGrabbed) return;

    currentlyGrabbed.transform.position = visualHand.position;
    if (currentlyGrabbed.preserveOrientation)
      currentlyGrabbed.transform.rotation = currentlyGrabbed.originalRotation;
  }

  // TODO: grab the thing that is in front of everything
  public Grabbable FindAvailableGrabbable () {
    Collider2D[] hits = Physics2D.OverlapCircleAll(Center, c.radius);

    int min = -1;
    for (int i=0; i<hits.Length; i++) {
      Grabbable found = hits[i].GetComponentInParent<Grabbable>();
      if (!found) continue;
      if (min == -1) {
        min = i;
        continue;
      }
      if ((hits[i].transform.position - Center).magnitude < (hits[min].transform.position - Center).magnitude) {
        min = i;
      }
    }

    if (min == -1) return null;
    return hits[min].GetComponentInParent<Grabbable>();
  }

  public void HandleGrab (InputAction.CallbackContext ctx) {
    if (hand.IsBlocked) return;

    if (!currentlyGrabbed) {
      AttemptGrab();
    } else {
      AttemptDrop();
    }
  }

  public void AttemptDrop () {
    currentlyGrabbed.Unuse();
    currentlyGrabbed = null;
    // hand.SpentAction();
  }

  public void AttemptGrab () {
    currentlyGrabbed = FindAvailableGrabbable();
    ForceGrab(currentlyGrabbed);
    // hand.SpentAction();
  }

  public void ForceGrab (Grabbable grabbable) {
    if (currentlyGrabbed) {
      currentlyGrabbed.Unuse();
      currentlyGrabbed = null;
    }
    currentlyGrabbed = grabbable;
    if (currentlyGrabbed) currentlyGrabbed.Use(this);
    if (currentlyGrabbed && currentlyGrabbed.isLocked) currentlyGrabbed = null;
  }

  public void DestroyGrabbed () {
    if (currentlyGrabbed) {
      Grabbable grabbed = currentlyGrabbed;
      ForceGrab(null);
      Destroy(grabbed.gameObject);
    }
  }
}
