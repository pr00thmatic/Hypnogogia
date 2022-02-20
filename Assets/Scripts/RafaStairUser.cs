using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaStairUser : MonoBehaviour {
  [Header("Information")]
  public Stairs currentStairs;
  public bool useSignalResetted = true;

  [Header("Initialization")]
  public Rafa rafa;
  public RafaStairsSkin upstairs;
  public RafaStairsSkin downstairs;

  void Reset () {
    rafa = GetComponentInParent<Rafa>();
  }

  void Update () {
    if (!currentStairs) return;
    Vector2 motion = TheInputInstance.Rafa.Walk.ReadValue<Vector2>();

    if (useSignalResetted && Mathf.Abs(motion.y) > 0.5) {
      useSignalResetted = false;
      if (motion.y > 0.5 && currentStairs.CanGoUp) {
        upstairs.Activate();
        upstairs.target = currentStairs.up;
      } else if (motion.y < -0.5 && currentStairs.CanGoDown) {
        downstairs.Activate();
        downstairs.target = currentStairs.down;
      }
    } else if (!useSignalResetted && Mathf.Abs(motion.y) < 0.5) {
      useSignalResetted = true;
    }
  }
}
