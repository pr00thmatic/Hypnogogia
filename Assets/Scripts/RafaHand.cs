using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaHand : MonoBehaviour {
  [Header("Configuration")]
  public float radius = 1;
  public float angle = 80f;
  public bool invertHand = true;

  [Header("Information")]
  public bool follow = false;
  public float debug;

  [Header("Initialization")]
  public RafaMetarigTransform metaRig;
  public Transform shoulder;
  public Transform arm1;

  void Update () {
    if (Input.GetMouseButtonUp(0)) {
      follow = false;
      metaRig.followCommands = false;
    }

    if (follow) {
      float z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
      Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,z));
      Vector3 d = point - shoulder.position;
      // if (d.normalized.y <= Mathf.Sin(angle)) d = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * d.magnitude;
      // if (d.normalized.y <= Mathf.Sin(-angle)) d = new Vector3(Mathf.Cos(-angle), Mathf.Sin(-angle), 0) * d.magnitude;
      debug = Vector3.Angle(Vector3.right, d);
      if (Vector3.Angle(Vector3.right, d) > angle) return;
      transform.position = Vector3.ClampMagnitude(d, radius) + shoulder.position;
      transform.up = (invertHand? -1: 1) * arm1.right;
      // if (Input.OnMouseButtonDown(0)) {
      //   Transform test = GameObject.CreatePrimitive(PrimitiveType.sphere).transform;
      //   test.position = transform.position;
      // }
    }
  }

  void OnMouseDown () {
    follow = true;
    metaRig.followCommands = true;
  }
}
