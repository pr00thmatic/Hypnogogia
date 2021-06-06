using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualPan : MonoBehaviour {
  [Header("Information")]
  public Pan originalPan;

  [Header("Initialization")]
  public Animator oil;
  public Transform whatsCookin;

  void Update () {
    oil.SetFloat("t", originalPan? Mathf.Clamp(originalPan.oil, 0, 1): 0);
  }
}
