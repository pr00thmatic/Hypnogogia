using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class SelectedHand : MonoBehaviour {
  [Header("Information")]
  public bool actionUsed;
  public bool IsBlocked { get => actionUsed; }

  void OnEnable () {
    actionUsed = false;
    TheInputInstance.Input.Rafa.Grab.canceled += HandleRelease;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Grab.canceled -= HandleRelease;
  }

  public void SpentAction () {
    actionUsed = true;
  }

  public void HandleRelease (InputAction.CallbackContext ctx) {
    actionUsed = false;
  }
}
