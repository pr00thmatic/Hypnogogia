using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class DeskForm : MonoBehaviour {
  public static event System.Action<DeskForm> onAnyGrabbed;
  public event System.Action onGrab;

  [Header("Configuration")]
  public bool blocked = false;
  public bool original = true;
  public bool submittable = true;

  [Header("Information")]
  public RafaPointingArm hand;

  [Header("Initialization")]
  public string key;
  public GameObject grabIndicator;
  public Grabbable outsideRepresentation;

  void OnEnable () {
    TheInputInstance.Rafa.Grab.performed += GetGrabbed;
    grabIndicator.SetActive(false);
  }

  void OnDisable () {
    TheInputInstance.Rafa.Grab.performed -= GetGrabbed;
    if (!original) {
      Destroy(gameObject);
      return;
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    if (blocked) return;
    if (c.GetComponentInParent<RafaPointingArm>()) {
      hand = c.GetComponentInParent<RafaPointingArm>();
      grabIndicator.SetActive(true);
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (c.GetComponentInParent<RafaPointingArm>()) {
      hand = null;
      grabIndicator.SetActive(false);
    }
  }

  public void GetGrabbed (InputAction.CallbackContext ctx) {
    if (!hand || blocked) return;
    transform.parent = hand.fingerTip;
    hand.grabbed = gameObject;
    onGrab?.Invoke();
    onAnyGrabbed?.Invoke(this);
  }
}
