using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class DuckDeactivator : MonoBehaviour {
  [Header("Initialization")]
  public GameObject open;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Duck.performed += HandleDuck;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Duck.performed -= HandleDuck;
  }

  public void HandleDuck (InputAction.CallbackContext ctx) {
    TheInputInstance.Input.Rafa.Duck.performed -= HandleDuck;
    StartCoroutine(_HandleDuck());
    open.SetActive(true);
  }
  IEnumerator _HandleDuck () {
    yield return new WaitForSeconds(1);
    transform.parent.gameObject.SetActive(false);
  }
}
