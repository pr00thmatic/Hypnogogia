using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateOnTriggerEnter : MonoBehaviour {
  [Header("Configuration")]
  public bool deactivateOnEnable = true;

  [Header("Initialization")]
  public GameObject toActivate;

  void OnEnable () {
    if (deactivateOnEnable) toActivate.SetActive(false);
  }

  void OnTriggerStay2D (Collider2D c) {
    if (c.GetComponent<RafaTutorialSensor>()) {
      toActivate.SetActive(true);
    }
  }
}
