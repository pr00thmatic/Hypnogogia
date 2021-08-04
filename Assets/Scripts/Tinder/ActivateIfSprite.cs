using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ActivateIfSprite : MonoBehaviour {
  [Header("Initialization")]
  public new SpriteRenderer renderer;
  public Sprite[] activators;
  public GameObject[] toActivate;

  void Update () {
    for (int i=0; i<activators.Length; i++) {
      if (renderer.sprite == activators[i]) {
        toActivate[i].SetActive(true);
        break;
      }
    }
  }
}
