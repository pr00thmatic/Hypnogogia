using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class HandRotation : MonoBehaviour {
  [Header("Initialization")]
  public LineRenderer arm;
  public Transform shoulder;
  public RafaMotion motion;
  public new SpriteRenderer renderer;

  void Update () {
    transform.up = shoulder.position - transform.position;
    renderer.flipX = motion.orientation < 0;
  }
}
