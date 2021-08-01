using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// me da flojera poner diálogos para esto xD
public class ColorVariant : MonoBehaviour {
  [Header("Configuration")]
  public int prefered;

  [Header("Information")]
  public int chosen;

  [Header("Initialization")]
  public Color[] colorVariants;
  public SpriteRenderer r;

  void Start () {
    Randomize();
  }

  public void Randomize () {
    chosen = Random.Range(0, colorVariants.Length);
    r.color = colorVariants[chosen];
  }
}
