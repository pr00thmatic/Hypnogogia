using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsableWithHand : MonoBehaviour {
  public event System.Action<RafaHand> onUse;

  [Header("Configuration")]
  public bool takesControl = true;

  [Header("Information")]
  public bool beingUsed = false;
  public bool canBeUsed;

  void OnDisable () {
    beingUsed = false;
    canBeUsed = false;
  }

  void OnTriggerStay (Collider c) {
    RafaHand hand = c.GetComponent<RafaHand>();
    if (!hand || hand.frameBlockedByInteraction) return;
    if (c.isTrigger && hand && hand.TimeFollowing > 0.2f && hand.follow) {
      canBeUsed = true;
      if (Input.GetMouseButton(0)) {
        hand.frameBlockedByInteraction = true;
        onUse?.Invoke(hand);
      }
      if (takesControl) {
        beingUsed = Input.GetMouseButton(0);
        if (beingUsed) {
          hand.currentlyUsedItem = this;
        } else if (hand.currentlyUsedItem == this) {
          hand.currentlyUsedItem = null;
        }
      }
    }
  }

  void OnTriggerExit (Collider c) {
    RafaHand hand = c.GetComponent<RafaHand>();
    if (c.isTrigger && hand && hand.TimeFollowing > 0.2f && hand.follow) {
      canBeUsed = false;
    }
  }
}
