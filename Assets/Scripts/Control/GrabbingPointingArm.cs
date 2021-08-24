using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class GrabbingPointingArm : MonoBehaviour {
  [Header("Information")]
  public ContextuallyGrabbable highlighted;
  public float DistanceToHighlighted {
    get => highlighted? Vector3.Distance(grabAnchor.position, highlighted.transform.position): Mathf.Infinity;
  }
  public ContextuallyGrabbable grabbed;

  [Header("Initialization")]
  public Transform grabAnchor;

  void OnEnable () {
    TheInputInstance.Rafa.Grab.performed += HandleGrab;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Grab.performed -= HandleGrab;
  }

  public void HandleGrab (InputAction.CallbackContext ctx) {
    if (!highlighted) return;
    if (grabbed && grabbed.canBeReleased) {
      grabbed.Unanchor();
      grabbed = null;
    } else if (!grabbed) {
      grabbed = highlighted;
      grabbed.AnchorTo(this);
    }
  }
}
