using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class FlickeringLight : MonoBehaviour {
  [Header("Configuration")]
  public float targetIntensity;
  public float speed = 3;
  public float x = 0;
  public float offTreshold = 0.3f;
  public bool randomStart = false;

  [Header("Initialization")]
  public Light2D myLight;

  void Reset () {
    myLight = GetComponent<Light2D>();
    targetIntensity = myLight.intensity;
  }

  void OnEnable () {
    if (randomStart) x = Random.Range(0, 100f);
  }

  void Update () {
    x += Time.deltaTime * speed;
    myLight.intensity = (Mathf.PerlinNoise(x, 0) < offTreshold? 0: 1) * targetIntensity;
  }
}
