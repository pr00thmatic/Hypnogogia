using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Sky : NonPersistentSingleton<Sky> {
  [Header("Configuration")]
  [Tooltip("in seconds")]
  public float dayDuration = 8;

  [Header("Information")]
  [Tooltip("the hour of the day (in hours)")]
  public float hour;
  public float NormalizedHour { get => hour / 24f; }

  [Header("Initialization")]
  public Renderer r;

  void Update () {
    if (Application.isPlaying) {
      hour += Time.deltaTime * (24 / dayDuration);
      hour %= 24;
    }
    r.sharedMaterial.SetFloat("Daytime", hour);
  }
}
