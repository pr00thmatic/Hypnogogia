using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(SurfaceMimicker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour {
  [Header("Configuration")]
  public bool keepsRotationUp = true;

  [Header("Information")]
  public GrabbingHand hand;
  public Quaternion originalRotation;
  public Vector3 offset;
  public bool IsGrabbed { get => hand; }

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
    if (hand) {
      if (keepsRotationUp) {
        transform.rotation = originalRotation;
      }
      // TODO: a prettier grab position
      transform.position = hand.movingHand.TransformPoint(offset);
    }
  }

  public void Use (GrabbingHand hand) {
    this.hand = hand;
    foreach (Collider2D c in cs) c.enabled = false;
    transform.parent = hand.movingHand;
    sortGroup.sortingOrder = hand.grabbedSortingOrder;
    body.velocity = Vector2.zero;
    body.isKinematic = true;
    CustomGripTransform customGrip = GetComponent<CustomGripTransform>();
    if (customGrip) {
      originalRotation = customGrip.gripTransform.localRotation;
      offset = customGrip.gripTransform.localPosition;
    } else {
      originalRotation = transform.rotation;
      offset = hand.movingHand.InverseTransformPoint(transform.position);
    }
  }

  public void Unuse () {
    this.hand = null;
    transform.parent = null;
    body.isKinematic = false;
    foreach (Collider2D c in cs) c.enabled = true;
  }
}
