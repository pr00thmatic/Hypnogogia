using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BouncingOption : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 3;

  [Header("Information")]
  public Vector3 initialPosition;

  [Header("Initialization")]
  public Rigidbody2D body;
  public TextMeshPro label;

  void OnEnable () {
    body.velocity = Random.insideUnitCircle.normalized * speed;
    initialPosition = transform.position;
  }

  void FixedUpdate () {
    if (body.velocity.magnitude < speed * 0.5f) {
      body.velocity = Random.insideUnitCircle.normalized * speed;
    }
    body.velocity = body.velocity.normalized * speed;
  }

  public void GetConsumed () {
    transform.position = initialPosition;
  }
}
