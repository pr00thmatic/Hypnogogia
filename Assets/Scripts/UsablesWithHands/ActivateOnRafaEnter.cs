using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateOnRafaEnter : MonoBehaviour {
  [Header("Initialization")]
  public GameObject toActivate;

  void OnTriggerEnter2D (Collider2D c) {
    if (!c.GetComponentInParent<RafaMotion>()) return;
    toActivate.SetActive(true);
  }
}
