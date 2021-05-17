using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabbingHand : MonoBehaviour {
  [Header("Configuration")]
  public int grabbedSortingOrder = -1;

  [Header("Information")]
  public Grabbable currentlyGrabbed;
  public Vector3 Center { get => (Vector3) c.offset + transform.position; }
  public static bool UserCommandDown { get => (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.G)); }
  public static bool UserCommandUp { get => (Input.GetMouseButtonUp(2) || Input.GetKeyUp(KeyCode.G)); }

  [Header("Initialization")]
  public Transform movingHand;
  public CircleCollider2D c;
  public UserHand user;
  public SelectedHand hand;

  void Update () {
    if (hand.IsBlocked) return;
    if (!UpdateDropAndContinue()) return;
    if (!UpdateGrabAndContinue()) return;
  }

  // returns false if the hand just picked up something
  public bool UpdateGrabAndContinue () {
    if (UserCommandDown && !currentlyGrabbed) {
      currentlyGrabbed = FindAvailableGrabbable();
      if (currentlyGrabbed) {
        currentlyGrabbed.Use(this);
        hand.SpentAction();
        return false;
      }
    }
    return true;
  }

  public Grabbable FindAvailableGrabbable () {
    Collider2D[] hits = Physics2D.OverlapCircleAll(Center, c.radius);

    int min = -1;
    for (int i=0; i<hits.Length; i++) {
      if (!hits[i].GetComponentInParent<Grabbable>()) continue;
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

  // returns false if the hand just dropped something
  public bool UpdateDropAndContinue () {
    if (UserCommandDown && currentlyGrabbed) {
      currentlyGrabbed.Unuse();
      currentlyGrabbed = null;
      hand.SpentAction();
      return false;
    }

    return true;
  }
}
