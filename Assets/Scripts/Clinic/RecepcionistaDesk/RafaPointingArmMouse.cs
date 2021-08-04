using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaPointingArmMouse : MonoBehaviour {
  [Header("Initialization")]
  public RafaPointingArm arm;

  void Update () {
    float z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
    Vector3 desiredPosition = Camera.main.ScreenToWorldPoint((Vector3) TheInputInstance.Input.Rafa.MouseHand.ReadValue<Vector2>() +
                                                             new Vector3(0,0,z));
    arm.MoveTo(desiredPosition);
  }
}
