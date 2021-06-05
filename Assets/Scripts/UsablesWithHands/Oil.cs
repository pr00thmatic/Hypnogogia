using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Oil : MonoBehaviour {
  [Header("Configuration")]
  public float useRotation = 90;
  public bool beingUsed = false;
  public float rotationSpeed = 90;
  public int orientation = -1;

  [Header("Information")]
  public bool locked = false;

  [Header("Initialization")]
  public Grabbable grabbable;

  void Update () {
    if (!grabbable.IsGrabbed) return;

    int rafaOrientation = grabbable.hand.GetComponentInParent<RafaMotion>().orientation * -1;
    Quaternion target = beingUsed? Quaternion.Euler(0,0, orientation * useRotation): Quaternion.identity;
    if (orientation != rafaOrientation) {
      transform.rotation = target;
    }

    orientation = rafaOrientation;
    beingUsed = TheInputInstance.Input.Rafa.Use.ReadValue<float>() > 0.1f;

    transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
    transform.rotation = Quaternion.Euler(Utils.SetX(Utils.SetY(transform.rotation.eulerAngles, 0), 0));
  }
}
