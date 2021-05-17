using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectedHand : MonoBehaviour {
  [Header("Information")]
  public bool actionUsed;
  public bool IsBlocked { get => actionUsed; }

  void OnEnable () {
    actionUsed = true;
  }

  void Update () {
    if (Input.GetMouseButtonUp(0) || GrabbingHand.UserCommandUp) {
      actionUsed = false;
    }
  }

  public void SpentAction () {
    actionUsed = true;
  }
}
