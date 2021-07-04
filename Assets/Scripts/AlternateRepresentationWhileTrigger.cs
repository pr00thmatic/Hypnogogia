using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlternateRepresentationWhileTrigger : MonoBehaviour {
  [Header("Initialization")]
  public SpriteRenderer alternative;
  public SpriteRenderer original;

  void OnTriggerStay2D (Collider2D c) {
    if (!c.GetComponent<GraphicRepresentationTriggerer>()) return;
    original.enabled = false;
    alternative.enabled = true;
  }

  void OnTriggerExit2D (Collider2D c) {
    if (!c.GetComponent<GraphicRepresentationTriggerer>()) return;
    original.enabled = true;
    alternative.enabled = false;
  }
}
