using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class Patient : MonoBehaviour {
  [Header("Initialization")]
  public SpriteResolver face;
  public SpriteResolver[] hair;
  public GameObject female;

  void OnEnable () {
    female.SetActive(Random.Range(0,1f) < 0.5f);
    Utils.RandomSkin(face);
    Utils.RandomSkin(hair);
  }
}
