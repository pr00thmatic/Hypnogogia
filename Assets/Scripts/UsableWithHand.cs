using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsableWithHand : MonoBehaviour {
  [Header("Information")]
  public bool beingUsed = false;

  void OnTriggerStay (Collider c) {
    RafaHand hand = c.GetComponent<RafaHand>();
    if (hand && hand.TimeFollowing > 0.2f) {
      beingUsed = Input.GetMouseButton(0);
      if (beingUsed) {
        hand.currentlyUsedItem = this;
      } else if (hand.currentlyUsedItem == this) {
        hand.currentlyUsedItem = null;
      }
    }
  }
}
