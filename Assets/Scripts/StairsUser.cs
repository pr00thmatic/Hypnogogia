using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StairsUser : MonoBehaviour {
  [Header("Initialization")]
  public Transform root;

  void OnTriggerStay2D (Collider2D c) {
    Stairs found = c.GetComponentInParent<Stairs>();
    if (!found) return;
    found.AddUser(this);
  }
}
