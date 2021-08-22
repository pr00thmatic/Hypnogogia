using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomColor : MonoBehaviour {
  [Header("Configuration")]
  public Color[] availableColors;

  [Header("Initialization")]
  public SpriteRenderer[] renderers;

  void OnEnable () {
    Color pick = Utils.RandomPick(availableColors);
    for (int i=0; i<renderers.Length; i++) {
      renderers[i].color = pick;
    }
  }
}
