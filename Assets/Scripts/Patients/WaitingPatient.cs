using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class WaitingPatient : MonoBehaviour {
  [Header("Configuration")]
  public bool canBeAttended;

  [Header("Initialization")]
  public WalkToEnfermeria walker;
  public GameObject interactIndicator;
  public Transform drPosition;

  [Header("Debug")]
  public bool go = false;

  void Update () {
    if (go) {
      go = false;
      GoToEnfermeria();
    }
  }

  public void GoToEnfermeria () {
    canBeAttended = false;
    walker.gameObject.SetActive(true);
  }
}
