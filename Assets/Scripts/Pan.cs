using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pan : MonoBehaviour, IOileable {
  [Header("Information")]
  public float oil;

  [Header("Initialization")]
  public Estufable estufable;
  public ParticleSystem steam;

  public void AddOil (float amount) {
    oil += amount;
  }

  void Update () {

  }
}
