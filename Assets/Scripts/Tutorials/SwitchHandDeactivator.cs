using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class SwitchHandDeactivator : MonoBehaviour {
  [Header("Initialization")]
  public GameObject switchHandTutorial;

  void OnEnable () {
    TheInputInstance.Input.Rafa.SwitchHand.performed += Hide;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.SwitchHand.performed -= Hide;
  }

  public void Hide (InputAction.CallbackContext ctx) {
    TheInputInstance.Input.Rafa.SwitchHand.performed -= Hide;
    StartCoroutine(_Hide());
  }

  IEnumerator _Hide () {
    yield return new WaitForSeconds(1);
    switchHandTutorial.SetActive(false);
  }
}
