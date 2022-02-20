using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stairs : MonoBehaviour {
  // [Header("Information")]
  public bool CanGoUp { get => up; }
  public bool CanGoDown { get => down; }

  [Header("Initialization")]
  public Transform usePosition;
  public Transform up;
  public Transform down;
  public Transform users;
  public Transform maskTop;
  public Transform maskBottom;
  public GameObject upIndicator;
  public GameObject downIndicator;

  void OnEnable () {
    upIndicator.SetActive(false);
    downIndicator.SetActive(false);
  }

  void OnTriggerEnter2D (Collider2D c) {
    RafaStairUser found = c.GetComponentInParent<RafaStairUser>();
    if (!found) return;
    found.currentStairs = this;
    upIndicator.SetActive(up);
    downIndicator.SetActive(down);
  }

  void OnTriggerExit2D (Collider2D c) {
    RafaStairUser found = c.GetComponentInParent<RafaStairUser>();
    if (!found) return;
    if (found.currentStairs == this) {
      found.currentStairs = null;
      upIndicator.SetActive(false);
      downIndicator.SetActive(false);
    }
  }

  // public void Go (Transform user, Transform target) {
  //   if (!target) return;
  //   // user.position = target.position;
  // }

  // public void GoUp (Transform user) {
  //   Go(user, up);
  // }

  // public void GoDown (Transform user) {
  //   Go(user, down);
  // }

  public void AddUser (StairsUser user) {
    user.root.parent = users;
  }
}
