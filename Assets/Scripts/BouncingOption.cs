using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BouncingOption : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 3;

  [Header("Initialization")]
  public Rigidbody2D body;
  public TextMeshPro label;

  void OnEnable () {
    body.velocity = Random.insideUnitCircle.normalized * speed;
  }

  void FixedUpdate () {
    if (body.velocity.magnitude < speed * 0.5f) {
      body.velocity = Random.insideUnitCircle.normalized * speed;
    }
    body.velocity = body.velocity.normalized * speed;
  }
}
