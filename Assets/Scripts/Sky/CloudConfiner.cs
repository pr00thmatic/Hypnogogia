using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudConfiner : MonoBehaviour {
  void Update () {
    Vector3 relativePosition = Camera.main.transform.InverseTransformPoint(transform.position);
    if (relativePosition.x > 36) {
      relativePosition.x = -35;
    } else if (relativePosition.x < -36) {
      relativePosition.x = 35;
    }
    transform.position = Camera.main.transform.TransformPoint(relativePosition);
  }
}
