using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaPointingArm : MonoBehaviour {
  [Header("Configuration")]
  public float radius = 5;

  [Header("Initialization")]
  public Transform center;
  public Transform fingerTip;
  public Transform rootMotion;

  public void MoveTo (Vector3 desiredPosition) {
    float d = Mathf.Min((center.position - desiredPosition).magnitude, radius);
    Vector3 forward = Utils.SetZ(desiredPosition - center.position, 0);

    if (forward.y < 0) return;
    rootMotion.up = forward;
    rootMotion.position = center.position + rootMotion.up * d + (rootMotion.position - fingerTip.position);
  }
}
