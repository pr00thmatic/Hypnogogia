using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FirelyLightsController : MonoBehaviour {
  [Header("Configuration")]
  public float value = 0.5f;

  [Header("Initialization")]
  public FirelyLight[] lights;
  public Transform fire;

  void Reset () {
    lights = GetComponentsInChildren<FirelyLight>();
  }

  void Update () {
    value = Mathf.Clamp(value, 0, 1);
    foreach (FirelyLight light in lights) {
      light.value = value;
      fire.localScale = Vector3.one * value;
    }
  }
}
