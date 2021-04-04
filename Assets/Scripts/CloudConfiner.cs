using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudConfiner : MonoBehaviour {
  void Update () {
    Vector3 relativePosition = Camera.main.transform.InverseTransformPoint(transform.position);
    if (relativePosition.x > 20) {
      relativePosition.x = -19;
    } else if (relativePosition.x < -20) {
      relativePosition.x = 19;
    }
    transform.position = Camera.main.transform.TransformPoint(relativePosition);
  }
}
