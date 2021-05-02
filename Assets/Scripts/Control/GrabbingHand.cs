using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabbingHand : MonoBehaviour {
  public const int BLOCKED_BY_DROP = 0, BLOCKED_BY_PICKUP = 1, BLOCKED_BY_ENABLE = 2;

  [Header("Configuration")]
  public int grabbedSortingOrder = -1;

  [Header("Information")]
  public Grabbable currentlyGrabbed;
  public bool[] blocked = new bool[3];
  public Vector3 Center { get => (Vector3) c.offset + transform.position; }

  [Header("Initialization")]
  public Transform movingHand;
  public CircleCollider2D c;

  void OnEnable () {
    blocked[BLOCKED_BY_ENABLE] = true;
  }

  void Update () {
    if (!UpdateBlockersAndContinue()) return;
    if (!UpdateDropAndContinue()) return;
    if (!UpdateGrabAndContinue()) return;
  }

  // returns false if something is blocking the grab/drop action
  public bool UpdateBlockersAndContinue () {
    if (Input.GetMouseButtonUp(0)) for (int i=0; i<blocked.Length; i++) blocked[i] = false;
    foreach (bool b in blocked) if (b) return false;
    return true;
  }

  // returns false if the hand just picked up something
  public bool UpdateGrabAndContinue () {
    if (Input.GetMouseButton(0) && !currentlyGrabbed) {
      currentlyGrabbed = FindAvailableGrabbable();
      if (currentlyGrabbed) {
        currentlyGrabbed.Use(this);
        blocked[BLOCKED_BY_PICKUP] = true;
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
    if (Input.GetMouseButtonDown(0) && currentlyGrabbed) {
      currentlyGrabbed.Unuse();
      currentlyGrabbed = null;
      blocked[BLOCKED_BY_DROP] = true;
      return false;
    }

    return true;
  }
}
