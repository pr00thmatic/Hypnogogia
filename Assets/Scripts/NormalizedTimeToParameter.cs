using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NormalizedTimeToParameter : MonoBehaviour {
  [Header("Configuration")]
  public string parameter;

  [Header("Information")]
  public float value = 0;

  [Header("Initialization")]
  public Animator animator;

  void Update () {
    value = (value + Time.deltaTime) % 1;
    animator.SetFloat(parameter, value);
  }
}
