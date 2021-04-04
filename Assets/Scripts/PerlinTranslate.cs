using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerlinTranslate : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange speedRange = new RandomRange(1, 2);
  public RandomRange maxSpeedRange = new RandomRange(0.3f, 0.5f);

  [Header("Information")]
  public RandomRange translationSpeedRange = new RandomRange(0, 0.3f);
  public float x;
  public float speed;

  void Start () {
    translationSpeedRange.Max = maxSpeedRange.Uniform;
    speed = speedRange.Uniform;
    x = Random.Range(0, 100f);
  }

  void Update () {
    x += Time.deltaTime * speed;
    transform.Translate(translationSpeedRange.Lerp(Mathf.PerlinNoise(x, 1)) * Time.deltaTime, 0, 0);
  }
}
