using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class HandMouseFollow : MonoBehaviour {
  [Header("Initialization")]
  public HandControl control;

  public void FixedUpdate () {
    float z = Mathf.Abs(control.motionTarget.position.z - Camera.main.transform.position.z);
    control.MoveTo(Camera.main.ScreenToWorldPoint((Vector3) TheInputInstance.Input.Rafa.MouseHand.ReadValue<Vector2>() +
                                                  new Vector3(0,0,z)));
  }
}
