using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ParentConstraint))]
[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour {
  [Header("Information")]
  public GrabbingHand hand;
  public Quaternion originalRotation;
  public Vector3 offset;

  [Header("Initialization")]
  public SortingGroup sortGroup;
  public Rigidbody2D body;

  void Reset () {
    sortGroup = GetComponent<SortingGroup>();
    body = GetComponent<Rigidbody2D>();
  }

  void Update () {
    if (hand) {
      transform.rotation = originalRotation;
      transform.position = hand.transform.position + offset;

      // if (hand.follow && Input.GetMouseButtonDown(0)) {
      //   Unuse();
      // }
    }
  }

  public void Use (GrabbingHand hand) {
    transform.parent = null;
    body.velocity = Vector2.zero;
    body.isKinematic = true;
    originalRotation = transform.rotation;
    offset = transform.position - hand.transform.position;
  }

  public void Unuse () {
    this.hand = null;
    transform.parent = null;
    body.isKinematic = false;
  }
}
