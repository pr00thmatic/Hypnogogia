using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Bezier : MonoBehaviour {
  [Header("Configuration")]
  public int resolution = 20;

  [Header("Initialization")]
  public Transform beginControlPoint;
  public Transform begin;
  public Transform endControlPoint;
  public Transform end;
  public LineRenderer body;

  void Update () {
    Vector3[] positions = new Vector3[resolution];

    Vector3 p0 = begin.position;
    Vector3 p1 = beginControlPoint? beginControlPoint.position: begin.position - Vector3.up * 0.2f;
    Vector3 p2 = endControlPoint? endControlPoint.position: ((begin.position + end.position) / 2f) - Vector3.up * 0.2f;
    p2.y = Mathf.Min(begin.position.y, Mathf.Min(end.position.y, p2.y));
    Vector3 p3 = end.position;

    for (int i=0; i<positions.Length; i++) {
      float t = i/((float) positions.Length - 1);

      positions[i] =
        Mathf.Pow(1-t, 3) * p0 +
        3 * Mathf.Pow(1-t, 2) * t * p1 +
        3 * (1-t) * Mathf.Pow(t,2) * p2 +
        Mathf.Pow(t, 3) * p3;
    }

    body.positionCount = positions.Length;
    body.SetPositions(positions);
  }
}
