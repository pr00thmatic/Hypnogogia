using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplashedEgg : MonoBehaviour {
  public Rigidbody2D body;

  void OnCollisionEnter2D (Collision2D c) {
    Destroy(body);
    Destroy(this);
  }
}
