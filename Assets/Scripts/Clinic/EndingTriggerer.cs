using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndingTriggerer : MonoBehaviour {
  [Header("Information")]
  public bool triggered = false;

  [Header("Initialization")]
  public Transform ending;

  void OnTriggerStay2D (Collider2D c) {
    if (triggered) return;
    if (Sky.Instance.IsTheEndOfTime && c.GetComponent<Rafa>()) {
      triggered = true;
      ending.gameObject.SetActive(true);
    }
  }
}
