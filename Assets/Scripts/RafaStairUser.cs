using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaStairUser : MonoBehaviour {
  [Header("Information")]
  public Stairs currentStairs;
  public bool useSignalResetted = true;

  [Header("Initialization")]
  public Rafa rafa;

  void Reset () {
    rafa = GetComponentInParent<Rafa>();
  }

  void Update () {
    if (!currentStairs) return;
    Vector2 motion = TheInputInstance.Rafa.Walk.ReadValue<Vector2>();

    if (useSignalResetted && Mathf.Abs(motion.y) > 0.5) {
      useSignalResetted = false;
      if (motion.y > 0.5) currentStairs.GoUp(rafa.motion.motionTarget);
      if (motion.y < -0.5) currentStairs.GoDown(rafa.motion.motionTarget);
    } else if (!useSignalResetted && Mathf.Abs(motion.y) < 0.5) {
      useSignalResetted = true;
    }
  }
}
