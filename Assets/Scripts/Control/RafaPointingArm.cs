using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaPointingArm : MonoBehaviour {
  [Header("Configuration")]
  public float radius = 5;

  [Header("Information")]
  public GameObject grabbed;
  public bool blockedBySubmission = false;

  [Header("Initialization")]
  public Transform grabAnchor;
  public Transform center;
  public Transform fingerTip;
  public Transform rootMotion;

  void OnDisable () {
    if (grabbed) Destroy(grabbed);
  }

  public void Grab (GameObject toGrab) {
    toGrab.transform.position = grabAnchor.position;
    toGrab.transform.rotation = grabAnchor.rotation;
    toGrab.transform.parent = transform;
    grabbed = toGrab;
  }

  public void MoveTo (Vector3 desiredPosition) {
    if (blockedBySubmission) return;
    float d = Mathf.Min((center.position - desiredPosition).magnitude, radius);
    Vector3 forward = Utils.SetZ(desiredPosition - center.position, 0);

    if (forward.y < 0) return;
    rootMotion.up = forward;
    rootMotion.position = center.position + rootMotion.up * d + (rootMotion.position - fingerTip.position);
  }
}
