using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Foco : MonoBehaviour {
  [Header("Configuration")]
  public bool turnsOnAutomatically = true;
  public AnimationCurve autoOn;

  // [Header("Information")]
  public bool IsOn {
    get => pic.sprite == on;
    set {
      pic.sprite = value? on: off;
      lights.SetActive(IsOn);
    }
  }

  [Header("Initialization")]
  public Sprite on;
  public Sprite off;
  public GameObject lights;
  public SpriteRenderer pic;

  void Update () {
    if (turnsOnAutomatically) {
      IsOn = autoOn.Evaluate(Sky.Instance.hour) > 0.5;
    }
  }

  public void Toggle () {
    IsOn = !IsOn;
  }
}
