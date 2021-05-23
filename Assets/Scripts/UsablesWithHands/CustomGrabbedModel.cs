using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomGrabbedModel : MonoBehaviour {
  [Header("Configuration")]
  public bool locksOnGrab = false;

  [Header("Information")]
  public bool locked = false;

  [Header("Initialization")]
  public GameObject grabbed;
  public GameObject notGrabbed;
  public Grabbable grabbable;

  void Update () {
    if (locked) return;

    if (grabbable.IsGrabbed) {
      grabbed.SetActive(true);
      notGrabbed.SetActive(false);
      if (locksOnGrab) locked = true;
    } else {
      grabbed.SetActive(false);
      notGrabbed.SetActive(true);
    }
  }
}
