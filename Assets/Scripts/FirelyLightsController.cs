using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FirelyLightsController : MonoBehaviour {
  [Header("Configuration")]
  public float value = 0.5f;

  [Header("Initialization")]
  public FirelyLight[] lights;

  void Reset () {
    lights = GetComponentsInChildren<FirelyLight>();
  }

  void Update () {
    foreach (FirelyLight light in lights) {
      light.value = value;
    }
  }
}
