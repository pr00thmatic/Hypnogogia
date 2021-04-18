using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FirelyLight : MonoBehaviour {
  [Header("Configuration")]
  public Vector2 intensityRange = new Vector2(0, 3.5f);
  public float value = 0;
  public float speed = 2;

  [Header("Information")]
  public float x;
  public float targetIntensity;

  [Header("Initialization")]
  public Light2D light;

  void Start () {
    x = Random.Range(1,100);
  }

  void Update () {
    targetIntensity = Mathf.Lerp(intensityRange.x, intensityRange.y, value);
    light.intensity = Mathf.Lerp(intensityRange.x, targetIntensity, Mathf.PerlinNoise(x, 1));
    x += speed * Time.deltaTime;
  }
}
