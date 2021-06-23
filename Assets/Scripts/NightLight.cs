using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class NightLight : MonoBehaviour {
  [Header("Configuration")]
  public float onTime = 19;
  public float offTime = 8;
  public float intensity;

  // [Header("Information")]
  public bool IsOn { get => Sky.Instance.hour < offTime || Sky.Instance.hour > onTime; }

  [Header("Initialization")]
  public Light2D myLight;
  public GameObject onStuff;
  public GameObject offStuff;

  void Reset () {
    myLight = GetComponent<Light2D>();
    intensity = myLight.intensity;
  }

  void Update () {
    // if (myLight) myLight.intensity = Sky.Instance.hour > offTime && Sky.Instance.hour < onTime? 0: intensity;
    if (myLight) myLight.intensity = IsOn? intensity: 0;
    if (onStuff) onStuff.SetActive(IsOn);
    if (offStuff) offStuff.SetActive(!IsOn);
  }
}
