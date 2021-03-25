using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomParameter : MonoBehaviour {
  [Header("Configuration")]
  public Vector2 value;
  public string parameter;

  [Header("Initialization")]
  public Animator animator;

  void Reset () {
    animator = GetComponent<Animator>();
  }

  void Start () {
    animator.SetFloat(parameter, Random.Range(value.x, value.y));
  }
}
