using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ladder : MonoBehaviour {
  [Header("Configuration")]
  public bool blocksMotionWhileUp;

  [Header("Information")]
  public bool climbedUp;

  [Header("Initialization")]
  public Transform startPose;
  public Transform endPose;
  public Transform distanceComparation;

  void OnTriggerStay2D (Collider2D c) {
    LadderUser user = c.GetComponent<LadderUser>();
    if (!user) return;
    if (user.current && user.current.blocksMotionWhileUp && user.current.climbedUp) return;
    if (!user.current) {
      user.current = this;
      return;
    }
    if (Vector3.Distance(distanceComparation.position, user.transform.position) <
        Vector3.Distance(user.current.distanceComparation.position, user.transform.position)) {
      user.current = this;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    LadderUser user = c.GetComponent<LadderUser>();
    if (!user) return;
    if (user.current != this) return;
    if (user.current.blocksMotionWhileUp && user.current.climbedUp) return;
    user.current = null;
  }
}
