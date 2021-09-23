using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(SurfaceMimicker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour {
  public event System.Action onLockedGrab;
  public event System.Action onDropped;
  public event System.Action<GrabbingHand> onGrabbed;

  [Header("Configuration")]
  public bool changeSortingGroup = true;
  public bool getsParented = true;
  public bool copiesHandPosition = true;
  public bool keepsRotationUp = true;
  public bool simulateWhileGrabbed = false;
  public bool preserveOrientation = false;
  public bool isLocked = false;

  [Header("Information")]
  public GrabbingHand hand;
  public Quaternion originalRotation;
  public Vector3 offset;
  public bool IsGrabbed { get => hand; }
  public bool couldBeGrabbed;

  [Header("Initialization")]
  public SortingGroup sortGroup;
  public Rigidbody2D body;
  public Collider2D[] cs;

  void Reset () {
    sortGroup = GetComponent<SortingGroup>();
    body = GetComponent<Rigidbody2D>();
    cs = new Collider2D[] { GetComponent<Collider2D>() };
    if (!cs[0]) {
      cs = GetComponentsInChildren<Collider2D>(true);
    }
  }

  void Update () {
    if (hand && copiesHandPosition) {
      if (isLocked) Unuse();
      if (keepsRotationUp) {
        transform.rotation = originalRotation;
        transform.localScale = Utils.SetX(transform.localScale,
                                          Mathf.Abs(transform.localScale.x) * (preserveOrientation? 1: hand.motion.orientation));
      }
      // TODO: a prettier grab position
      transform.position = hand.movingHand.TransformPoint(offset);
    }
  }

  public void Use (GrabbingHand hand) {
    GetComponent<SurfaceMimicker>().enabled = false;
    this.hand = hand;
    foreach (Collider2D c in cs) c.enabled = false;
    if (getsParented) {
      transform.parent = hand.movingHand;
    }
    if (changeSortingGroup) {
      sortGroup.sortingOrder = hand.grabbedSortingOrder;
    }
    body.velocity = Vector2.zero;
    body.isKinematic = true;
    body.simulated = simulateWhileGrabbed;
    CustomGripTransform customGrip = GetComponent<CustomGripTransform>();
    if (customGrip) {
      originalRotation = customGrip.gripTransform.localRotation;
      offset = customGrip.gripTransform.localPosition;
    } else {
      originalRotation = transform.rotation;
      offset = hand.movingHand.InverseTransformPoint(transform.position);
    }
    onGrabbed?.Invoke(hand);
  }

  public void Unuse () {
    GetComponent<SurfaceMimicker>().enabled = true;
    this.hand = null;
    transform.parent = null;
    body.isKinematic = false;
    body.simulated = true;
    foreach (Collider2D c in cs) c.enabled = true;
    onDropped?.Invoke();
  }

  public void TriggerLockedGrab () {
    onLockedGrab?.Invoke();
  }
}
