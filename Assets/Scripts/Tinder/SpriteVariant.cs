using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteVariant : Variant {
  [Header("Initialization")]
  public Sprite[] variants;
  public SpriteRenderer[] renderers;

  void Reset () {
    renderers = GetComponentsInChildren<SpriteRenderer>();
  }

  public override void Set () {
    Sprite pick = variants[chosen];
    foreach (SpriteRenderer renderer in renderers) {
      renderer.sprite = pick;
    }
  }
}
