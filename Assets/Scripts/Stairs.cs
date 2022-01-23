using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stairs : MonoBehaviour {
  [Header("Initialization")]
  public Transform usePosition;
  public Transform up;
  public Transform down;
  public ControlTaker taker;
  public Transform users;
  public Transform maskTop;
  public Transform maskBottom;

  void Reset () {
    taker = GetComponentInChildren<ControlTaker>();
    if (!taker) {
      taker = new GameObject(name + " ControlTaker").AddComponent<ControlTaker>();
      taker.transform.parent = transform;
    }
  }

  void OnTriggerEnter2D (Collider2D c) {
    RafaStairUser found = c.GetComponentInParent<RafaStairUser>();
    if (!found) return;
    found.currentStairs = this;
  }

  void OnTriggerExit2D (Collider2D c) {
    RafaStairUser found = c.GetComponentInParent<RafaStairUser>();
    if (!found) return;
    if (found.currentStairs == this) found.currentStairs = null;
  }

  public void Go (Transform user, Transform target) {
    if (!target) return;
    user.position = target.position;
  }

  public void GoUp (Transform user) {
    Go(user, up);
  }

  public void GoDown (Transform user) {
    Go(user, down);
  }

  public void AddUser (StairsUser user) {
    user.transform.parent = users;
    Utils.CopyTransform(users, user.transform);
  }
}
