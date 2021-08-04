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
  public GameObject give;
  public RecepcionistaGrabingHand grabingHand;

  void OnEnable () {
    TheInputInstance.Rafa.Talk.performed += HandleAsk;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Talk.performed -= HandleAsk;
  }

  public void HandleAsk (InputAction.CallbackContext ctx) {
    if (askArea.IsPointing && !give.activeSelf) {
      give.SetActive(true);
      grabingHand.animator.SetTrigger(trigger);
    }
  }
}
