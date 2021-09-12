using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ArmEndControlPoint : MonoBehaviour {
  [Header("Configuration")]
  public float rightDistance = 0.5f;
  public float downDistance = 0.5f;

  [Header("Initialization")]
  public Transform begin;
  public Transform end;
  public RafaMotion motion;

  void Update () {
    Vector3 d = begin.position - end.position;
    Vector3 p = begin.position * 0.7f + end.position * 0.3f;
    p.x -= motion.orientation * rightDistance *
      Mathf.Lerp(0,1, Mathf.Abs(d.y) / 0.6f);
    p.y -= downDistance *
      Mathf.Lerp(1, 0, Mathf.Abs(d.x) / 0.6f) * Mathf.Lerp(1,0, Mathf.Abs(d.y) / 0.6f);
    transform.position = p;
  }
}
