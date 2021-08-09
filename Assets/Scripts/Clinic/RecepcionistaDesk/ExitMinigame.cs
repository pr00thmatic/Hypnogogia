using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ExitMinigame : MonoBehaviour {
  [Header("Initialization")]
  public GameObject window;

  void OnEnable () {
    TheInputInstance.Rafa.Cancel.performed += CloseWindow;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Cancel.performed -= CloseWindow;
  }

  public void CloseWindow (InputAction.CallbackContext ctx) {
    window.SetActive(false);
  }
}
