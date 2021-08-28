using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSpriteOnEnable : MonoBehaviour {
  [Header("Initialization")]
  public Sprite[] available;
  public new SpriteRenderer renderer;

  void OnEnable () {
    renderer.sprite = Utils.RandomPick(available);
  }
}
