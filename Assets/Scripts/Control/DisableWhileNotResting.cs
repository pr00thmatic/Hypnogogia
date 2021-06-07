using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisableWhileNotResting : MonoBehaviour {
  [Header("Initialization")]
  public Rigidbody2D body;
  public GameObject target;

  void Update () {
    if (body.velocity.magnitude > 0.1f ||
        body.angularVelocity > 20) {
      target.SetActive(false);
    }
  }
}
