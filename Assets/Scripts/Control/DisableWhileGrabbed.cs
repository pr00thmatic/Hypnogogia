using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisableWhileGrabbed : MonoBehaviour {
  [Header("Initialization")]
  public GameObject toDisable;
  public Grabbable grabbable;

  void Update () {
    toDisable.SetActive(!grabbable.IsGrabbed);
  }
}
