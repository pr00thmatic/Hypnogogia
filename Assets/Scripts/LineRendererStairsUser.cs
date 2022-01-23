using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineRendererStairsUser : MonoBehaviour {
  [Header("Information")]
  public Stairs currentStairs;

  [Header("Initialization")]
  public LineRenderer[] lines;

  void OnTriggerStay2D (Collider2D c) {
    Stairs found = c.GetComponentInParent<Stairs>();
    if (!found) return;
    currentStairs = found;
  }

  void Update () {
    if (!currentStairs) {
      foreach (LineRenderer line in lines)
        line.material.SetVector("yRange", new Vector2(-Mathf.Infinity, Mathf.Infinity));
      return;
    }
    foreach (LineRenderer line in lines)
      line.material.SetVector("yRange", new Vector2(currentStairs.maskBottom.position.y, currentStairs.maskTop.position.y));
  }
}
