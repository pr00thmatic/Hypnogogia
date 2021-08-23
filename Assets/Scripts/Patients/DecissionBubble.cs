using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class DecissionBubble : MonoBehaviour {
  public event System.Action<DecissionBubble> onDecissionMade;

  [Header("Information")]
  public RafaPointingArm pointing;

  [Header("Initialization")]
  public GameObject interactionIndicator;

  void OnEnable () { TheInputInstance.Rafa.Grab.performed += HandleDecissionAttempt; }
  void OnDisable () { TheInputInstance.Rafa.Grab.performed -= HandleDecissionAttempt; }

  void OnTriggerStay2D (Collider2D c) {
    RafaPointingArm found = c.GetComponentInParent<RafaPointingArm>();
    if (!found) return;
    pointing = found;
    if (interactionIndicator) interactionIndicator.SetActive(true);
  }

  void OnTriggerExit2D (Collider2D c) {
    RafaPointingArm found = c.GetComponentInParent<RafaPointingArm>();
    if (!found) return;
    if (pointing == found) {
      if (interactionIndicator) interactionIndicator.SetActive(false);
      pointing = null;
    }
  }

  public void HandleDecissionAttempt (InputAction.CallbackContext ctx) {
    if (!pointing) return;
    onDecissionMade?.Invoke(this);
  }
}
