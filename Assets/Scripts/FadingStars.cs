using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FadingStars : MonoBehaviour {
  [Header("Configuration")]
  public AnimationCurve fading;
  public Vector2 speedRange = new Vector2(0.5f, 1.5f);
  public float twinkleFalloff = 0.4f;
  public Vector2 offsetRange = new Vector2(-0.1f, 0.1f);

  [Header("Information")]
  public float x;
  public float y = 1;
  public float offset;
  public float speed;
  public float alpha;
  public float t;

  [Header("Initialization")]
  public SpriteRenderer r;

  void Start () {
    offset = Random.Range(offsetRange.x, offsetRange.y);
    x = Random.Range(0, 100f);
    speed = Random.Range(speedRange.x, speedRange.y);
  }

  void Reset () {
    r = GetComponent<SpriteRenderer>();
  }

  void Update () {
    if (Application.isPlaying) {
      x += speed * Time.deltaTime;
    }
    alpha = (1 - Mathf.PerlinNoise(x, 1) * twinkleFalloff) * fading.Evaluate(Sky.Instance.NormalizedHour + offset);
    r.color = new Color(1,1,1, alpha);
    t = Sky.Instance.NormalizedHour;
  }
}
