using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Sky : NonPersistentSingleton<Sky> {
  [Header("Configuration")]
  [Tooltip("in seconds")]
  public float dayDuration = 8;
  public float endOfTime = 23.75f;

  [Header("Information")]
  [Tooltip("the hour of the day (in hours)")]
  public float hour;
  public float NormalizedHour { get => hour / 24f; }
  public bool IsTheEndOfTime { get => hour == endOfTime; }

  [Header("Initialization")]
  public Renderer r;

  void Update () {
    if (Application.isPlaying) {
      hour += Time.deltaTime * (24 / dayDuration);
    }
    KeepRational();
  }

  public void KeepRational () {
    hour = (hour + 24 * ((int) (Mathf.Abs(hour) / 24))) % 24;
    if (endOfTime > 0) {
      hour = Mathf.Max(0, Mathf.Min(hour, endOfTime));
    }
    r.sharedMaterial.SetFloat("Daytime", hour);
  }
}
