using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FacadeInterior : MonoBehaviour {
  [Header("Initialization")]
  public GameObject facade;

  void OnTriggerEnter2D (Collider2D c) {
    if (c.GetComponentInParent<Rafa>()) facade.SetActive(false);
  }

  void OnTriggerExit2D (Collider2D c) {
    if (c.GetComponentInParent<Rafa>()) facade.SetActive(true);
  }
}
