using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bench : MonoBehaviour {
  public event System.Action<bool, SittingRafa> onUse;

  [Header("Initialization")]
  public GameObject actionIndicator;

  void OnTriggerStay2D (Collider2D c) {
    BenchUser user = c.GetComponent<BenchUser>();
    if (user) {
      user.bench = this;
      actionIndicator.SetActive(true);
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    BenchUser user = c.GetComponent<BenchUser>();
    if (user) {
      if (user.bench == this) user.bench = null;
      actionIndicator.SetActive(false);
    }
  }

  public void SetUsing (bool value, SittingRafa user) {
    onUse?.Invoke(value, user);
  }
}
