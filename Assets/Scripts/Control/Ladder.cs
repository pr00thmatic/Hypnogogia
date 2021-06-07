using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ladder : MonoBehaviour {
  [Header("Configuration")]
  public bool blocksMotionWhileUp;
  public float angleToDisable = 70;

  [Header("Information")]
  public bool climbedUp;
  public bool blocked;
  public LadderUser user;

  [Header("Initialization")]
  public Transform startPose;
  public Transform endPose;
  public Transform distanceComparation;
  public Rigidbody2D body;

  void Update () {
    blocked = (Vector3.Angle(transform.up, Vector3.up) > angleToDisable ||
               (!body || body.velocity.magnitude > 0.25f || body.angularVelocity > 20));
    if (blocked && user) {
      if (climbedUp) {
        user.ClimbDown();
      } else {
        user.current = null;
        user = null;
      }
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    if (blocked) return;
    LadderUser user = c.GetComponent<LadderUser>();
    if (!user) return;
    if (user.current && user.current.blocksMotionWhileUp && user.current.climbedUp) return;
    if (!user.current) {
      this.user = user;
      user.current = this;
      return;
    }
    if (Vector3.Distance(distanceComparation.position, user.transform.position) <
        Vector3.Distance(user.current.distanceComparation.position, user.transform.position)) {
      user.current.user = null;
      user.current = this;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (blocked) return;
    LadderUser user = c.GetComponent<LadderUser>();
    if (!user) return;
    if (user.current != this) return;
    if (user.current.blocksMotionWhileUp && user.current.climbedUp) return;
    this.user = null;
    user.current = null;
  }
}
