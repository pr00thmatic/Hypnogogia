using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Grabbable : MonoBehaviour {
  [Header("Information")]
  public GrabbingHand hand;
  public Quaternion originalRotation;
  public Vector3 offset;

  [Header("Initialization")]
  public SortingGroup sortGroup;
  public Rigidbody2D body;
  public Collider2D c;

  void Reset () {
    sortGroup = GetComponent<SortingGroup>();
    body = GetComponent<Rigidbody2D>();
    c = GetComponent<Collider2D>();
  }

  void Update () {
    if (hand) {
      transform.rotation = originalRotation;
      // TODO: a prettier grab position
      transform.position = hand.movingHand.TransformPoint(offset);
    }
  }

  public void Use (GrabbingHand hand) {
    this.hand = hand;
    c.enabled = false;
    transform.parent = hand.movingHand;
    sortGroup.sortingOrder = hand.grabbedSortingOrder;
    body.velocity = Vector2.zero;
    body.isKinematic = true;
    originalRotation = transform.rotation;
    offset = hand.movingHand.InverseTransformPoint(transform.position);
  }

  public void Unuse () {
    this.hand = null;
    transform.parent = null;
    body.isKinematic = false;
    c.enabled = true;
  }
}
