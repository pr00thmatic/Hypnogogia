using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateOnRafaEnter : MonoBehaviour {
  [Header("Initialization")]
  public GameObject toActivate;

  void OnTriggerEnter (Collider c) {
    if (!c.GetComponent<Rafa>()) return;
    toActivate.SetActive(true);
  }
}
