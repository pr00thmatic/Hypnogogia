using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsableWithHand : MonoBehaviour {
  public event System.Action<UserHand> onUse;
  public event System.Action<UserHand> onUseBegin;

  [Header("Configuration")]
  public bool takesControl = true;

  [Header("Information")]
  public bool beingUsed = false;
  public bool canBeUsed;
  public UserHand hand;

  void OnDisable () {
    beingUsed = false;
    canBeUsed = false;
  }

  void Update () {
    if (!canBeUsed) return;
    if (Input.GetMouseButton(0)) {
      if (Input.GetMouseButtonDown(0)) onUseBegin?.Invoke(hand);
      hand.blockedByInteraction = true;
      onUse?.Invoke(hand);
    }
    if (takesControl && Input.GetMouseButtonDown(0)) {
      beingUsed = true;
      hand.currentlyUsedItem = this;
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    UserHand hand = c.GetComponent<UserHand>();
    if (!hand || hand.Blocked) return;
    canBeUsed = true;
    this.hand = hand;
  }

  void OnTriggerExit2D (Collider2D c) {
    UserHand hand = c.GetComponent<UserHand>();
    if (hand && !hand.Blocked) {
      canBeUsed = false;
    }
  }

  public void StopUsing () {
    beingUsed = false;
    hand.currentlyUsedItem = null;
    hand = null;
  }
}
