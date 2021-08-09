using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PilaDePapeles : MonoBehaviour {
  [Header("Configuration")]
  public string trigger;

  [Header("Initialization")]
  public PointingArea askArea;
  public PointingArea takeArea;
  public RecepcionistaGrabingHand grabingHand;

  void OnEnable () {
    TheInputInstance.Rafa.Talk.performed += HandleAsk;
    TheInputInstance.Rafa.Grab.performed += HandleGrab;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Talk.performed -= HandleAsk;
    TheInputInstance.Rafa.Grab.performed -= HandleGrab;
  }

  public void HandleAsk (InputAction.CallbackContext ctx) {
    if (askArea.IsPointing) {
      grabingHand.HandForm(trigger);
    }
  }

  public void HandleGrab (InputAction.CallbackContext ctx) {
    if (takeArea.IsPointing) grabingHand.DontTouch(trigger);
  }
}
