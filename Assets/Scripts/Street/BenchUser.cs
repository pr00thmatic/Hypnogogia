using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class BenchUser : MonoBehaviour {
  [Header("Information")]
  public Bench bench;

  [Header("Initialization")]
  public GameObject sittingRafa;

  void OnEnable () { StartCoroutine(_OnEnable()); }
  IEnumerator _OnEnable () {
    yield return null;
    TheInputInstance.Rafa.Interact.performed += HandleUse;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Interact.performed -= HandleUse;
  }

  public void HandleUse (InputAction.CallbackContext ctx) {
    if (!bench) return;
    sittingRafa.GetComponent<SittingRafa>().bench = bench;
    sittingRafa.SetActive(true);
  }
}
