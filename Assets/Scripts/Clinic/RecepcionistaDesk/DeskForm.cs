using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class DeskForm : MonoBehaviour {
  public event System.Action onGrab;
  [Header("Configuration")]
  public bool blocked = false;

  [Header("Information")]
  public RafaPointingArm hand;

  [Header("Initialization")]
  public GameObject grabIndicator;

  void OnEnable () {
    TheInputInstance.Rafa.Grab.performed += GetGrabbed;
    grabIndicator.SetActive(false);
  }

  void OnDisable () {
    TheInputInstance.Rafa.Grab.performed -= GetGrabbed;
  }

  void OnTriggerStay2D (Collider2D c) {
    if (blocked) return;
    hand = c.GetComponentInParent<RafaPointingArm>();
    grabIndicator.SetActive(hand && !blocked);
  }

  void OnTriggerExit2D (Collider2D c) {
    hand = null;
    grabIndicator.SetActive(false);
  }

  public void GetGrabbed (InputAction.CallbackContext ctx) {
    if (!hand || blocked) return;
    transform.parent = hand.fingerTip;
    onGrab?.Invoke();
  }
}
