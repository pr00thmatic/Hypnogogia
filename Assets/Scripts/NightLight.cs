using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class NightLight : MonoBehaviour {
  [Header("Configuration")]
  public float onTime = 19;
  public float offTime = 8;
  public float intensity;

  [Header("Initialization")]
  public Light2D myLight;

  void Reset () {
    myLight = GetComponent<Light2D>();
    intensity = myLight.intensity;
  }

  void Update () {
    myLight.intensity = Sky.Instance.hour > offTime && Sky.Instance.hour < onTime? 0: intensity;
  }
}
