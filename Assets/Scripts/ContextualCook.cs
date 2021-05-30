using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualCook : MonoBehaviour {
  [Header("Configuration")]
  public float cookingTime = 3;
  [Range(0,1)]
  public float cookingFactor;

  [Header("Information")]
  public ContextualStove stove;

  void OnEnable () {
    stove = GetComponentInParent<ContextualStove>();
  }

  void OnDisable () {
    stove = null;
  }

  void Update () {
    if (!stove) return;
    cookingFactor += (Time.deltaTime / cookingTime) * stove.originalFire.value;
  }
}
