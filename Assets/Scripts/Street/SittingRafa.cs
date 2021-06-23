using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class SittingRafa : MonoBehaviour {
  [Header("Initialization")]
  public GameObject standingRafa;
  public Bench bench;

  void OnEnable () { StartCoroutine(_OnEnable()); }
  IEnumerator _OnEnable () {
    yield return null;
    TheInputInstance.Rafa.Interact.performed += HandleUse;
    if (bench) bench.SetUsing(true, this);
  }

  void OnDisable () {
    TheInputInstance.Rafa.Interact.performed -= HandleUse;
    if (bench) bench.SetUsing(false, this);
    bench = null;
  }

  public void HandleUse (InputAction.CallbackContext ctx) {
    standingRafa.SetActive(true);
  }
}
