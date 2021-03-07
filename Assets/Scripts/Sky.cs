using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sky : NonPersistentSingleton<Sky> {
  [Header("Configuration")]
  [Tooltip("in seconds")]
  public float dayDuration = 8;

  [Header("Information")]
  [Tooltip("the hour of the day (in hours)")]
  public float hour;
  public float t;

  [Header("Initialization")]
  public Renderer r;

  void Update () {
    t += Time.deltaTime;
    hour += Time.deltaTime * (24 / dayDuration);
    hour %= 24;
    r.sharedMaterial.SetFloat("Vector1_8a370ed6df694aa9a738f799e7131297", hour);
  }
}
