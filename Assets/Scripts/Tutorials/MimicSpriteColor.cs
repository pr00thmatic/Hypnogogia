using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MimicSpriteColor : MonoBehaviour {
  [Header("Initialization")]
  public SpriteRenderer mimo;
  public SpriteRenderer original;

  void Update () {
    mimo.color = original.color;
  }
}
