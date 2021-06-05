using UnityEngine;
using UnityEngine.InputSystem;
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
  public bool fired = false;
  public bool holding = false;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Grab.performed += HandleUse;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Grab.performed -= HandleUse;
    beingUsed = false;
    canBeUsed = false;
  }

  void Update () {
    if (!canBeUsed) return;
    if (holding) onUse?.Invoke(hand);
  }

  void OnTriggerStay2D (Collider2D c) {
    UserHand hand = c.GetComponent<UserHand>();
    if (!hand) return;
    if (hand.Blocked) {
      canBeUsed = false;
    } else {
      canBeUsed = true;
    }
    this.hand = hand;
  }

  void OnTriggerExit2D (Collider2D c) {
    UserHand hand = c.GetComponent<UserHand>();
    if (hand && !hand.Blocked) {
      canBeUsed = false;
    }
  }

  public void HandleUse (InputAction.CallbackContext ctx) {
    if (!canBeUsed) return;
    onUseBegin?.Invoke(hand);
    if (takesControl) {
      beingUsed = true;
      hand.currentlyUsedItem = this;
    }
    holding = true;
    hand.SpentAction();
  }

  public void StopUsing () {
    beingUsed = false;
    hand.currentlyUsedItem = null;
    hand = null;
  }
}
