using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReleasableArea : MonoBehaviour {
  public event System.Action<ContextuallyGrabbable> onReleased;

  [Header("Information")]
  public ContextuallyGrabbable possibleRelease;
  public bool CanSomeoneBeReleasedInMe { get => possibleRelease; }
  public bool blocked = false;

  void OnTriggerStay2D (Collider2D c) {
    ContextuallyGrabbable grabbable = c.GetComponentInParent<ContextuallyGrabbable>();
    if (!grabbable || !grabbable.IsGrabbed || grabbable.area != this) return;
    possibleRelease = grabbable;
  }

  void OnTriggerExit2D (Collider2D c) {
    ContextuallyGrabbable grabbable = c.GetComponentInParent<ContextuallyGrabbable>();
    if (!grabbable) return;
    possibleRelease = null;
  }

  public void TriggerRelease (ContextuallyGrabbable grabbable) {
    onReleased?.Invoke(grabbable);
  }
}
