using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wasd : MonoBehaviour {
  [Header("Information")]
  public bool triggered = false;

  void Update () {
    if (triggered) return;
    if (Mathf.Abs(TheInputInstance.Input.Rafa.Walk.ReadValue<Vector2>().x) > 0.1f) {
      triggered = true;
      StartCoroutine(_TurnOff());
    }
  }

  IEnumerator _TurnOff () {
    yield return new WaitForSeconds(1);
    gameObject.SetActive(false);
  }
}
