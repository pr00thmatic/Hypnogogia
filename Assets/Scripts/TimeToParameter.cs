using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeToParameter : MonoBehaviour {
  [Header("Configuration")]
  public string parameter = "t";
  public float offset = 0.5f;

  [Header("Initialization")]
  public Animator animator;

  void Reset () {
    animator = GetComponent<Animator>();
  }

  void Update () {
    animator.SetFloat(parameter, Sky.Instance.NormalizedHour + offset);
  }
}
