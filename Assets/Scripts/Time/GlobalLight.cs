using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class GlobalLight : ArtificialLight {
  [Header("Configuration")]
  public Gradient color;

  public override void Update () {
    base.Update();
    myLight.color = color.Evaluate(Sky.Instance.hour / 24f);
  }
}
