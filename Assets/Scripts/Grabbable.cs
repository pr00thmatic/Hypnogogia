using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UsableWithHand))]
[RequireComponent(typeof(ParentConstraint))]
[RequireComponent(typeof(SortingGroup))]
[RequireComponent(typeof(Rigidbody2D))]
public class Grabbable : MonoBehaviour {
  [Header("Information")]
  public RafaHand hand;
  public Quaternion originalRotation;
  public float timestampCooldown = -1;
  public float Cooldown { get => Time.time - timestampCooldown; }
  public Vector3 offset;

  [Header("Initialization")]
  public UsableWithHand usable;
  public SortingGroup sortGroup;
  public Rigidbody2D body;

  void Reset () {
    usable = GetComponent<UsableWithHand>();
    usable.takesControl = false;
    sortGroup = GetComponent<SortingGroup>();
    body = GetComponent<Rigidbody2D>();
  }

  void Update () {
    if (hand) {
      transform.rotation = originalRotation;
      // body.MovePosition(hand.transform.position + offset);
      transform.position = hand.transform.position + offset;

      if (hand.follow && Input.GetMouseButtonDown(0) && !hand.frameBlockedByInteraction) {
        Unuse();
      }
    }
  }

  public void Use (RafaHand hand) {
    if (Cooldown < 0.05f || hand.frameBlockedByInteraction) return;
    if (!hand.Busy && this.hand != hand) {
      hand.frameBlockedByInteraction = true;
      this.hand = hand;
      hand.grabbed = this;
      // body.isKinematic = true;
      originalRotation = transform.rotation;
      offset = transform.position - hand.transform.position;
      // transform.parent = hand.transform;
      // sortGroup.sortingLayerName = hand.GetComponent<SortingGroup>().sortingLayerName;
      // sortGroup.sortingOrder = hand.grabbedSortOffset;
      timestampCooldown = Time.time;
    }
  }

  public void Unuse () {
    if (Cooldown < 0.05f || hand.frameBlockedByInteraction) return;
    if (hand.grabbed == this) hand.grabbed = null;
    hand.frameBlockedByInteraction = true;
    this.hand = null;
    transform.parent = null;
    body.isKinematic = false;
    timestampCooldown = Time.time;
  }
}
