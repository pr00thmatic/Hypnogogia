using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class GrabbingHand : MonoBehaviour {
  [Header("Configuration")]
  public int grabbedSortingOrder = -1;

  [Header("Information")]
  public Grabbable currentlyGrabbed;
  public Vector3 Center { get => (Vector3) c.offset + transform.position; }

  [Header("Initialization")]
  public RafaMotion motion;
  public Transform movingHand;
  public CircleCollider2D c;
  public UserHand user;
  public SelectedHand hand;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Grab.performed += HandleGrab;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Grab.performed -= HandleGrab;
  }

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

    if (currentlyGrabbed) {
      currentlyGrabbed.Unuse();
      currentlyGrabbed = null;
      hand.SpentAction();
    } else {
      currentlyGrabbed = FindAvailableGrabbable();
      if (currentlyGrabbed && currentlyGrabbed.isLocked) {
        currentlyGrabbed.TriggerLockedGrab();
        currentlyGrabbed = null;
      } else if (currentlyGrabbed) {
        currentlyGrabbed.Use(this);
        hand.SpentAction();
      }
    }
  }
}
