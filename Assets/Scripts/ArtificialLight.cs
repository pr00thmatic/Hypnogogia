using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class ArtificialLight : MonoBehaviour {
  [Header("Configuration")]
  public AnimationCurve lightValue;
  public float targetIntensity = 1;

  [Header("Initialization")]
  public Light2D myLight;

  void Reset () {
    myLight = GetComponent<Light2D>();
  }

  public virtual void Update () {
    myLight.intensity = lightValue.Evaluate(Sky.Instance.hour) * targetIntensity;
  }
}
