using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggeredByRafa : MonoBehaviour {
  public event System.Action<TriggeredByRafa> onEnter;
  public event System.Action<TriggeredByRafa> onStay;
  public event System.Action<TriggeredByRafa> onExit;

  void OnTriggerStay2D (Collider2D c) {
    if (!c.GetComponent<Rafa>()) return;
    onStay?.Invoke(this);
  }

  void OnTriggerEnter2D (Collider2D c) {
    if (!c.GetComponent<Rafa>()) return;
    onEnter?.Invoke(this);
  }

  void OnTriggerExit2D (Collider2D c) {
    if (!c.GetComponent<Rafa>()) return;
    onExit?.Invoke(this);
  }
}
