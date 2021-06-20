using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchHand : MonoBehaviour {
  [Header("Information")]
  public bool triggered = false;

  [Header("Initialization")]
  public GameObject switchHandTutorial;
  public GameObject moveHandTutorial;

  void Update () {
    if (TheInputInstance.Input.Rafa.MoveHand.ReadValue<Vector2>().magnitude > 0.1f) {
      triggered = true;
      StartCoroutine(_TurnOff());
    }
  }

  IEnumerator _TurnOff () {
    yield return new WaitForSeconds(1);
    moveHandTutorial.SetActive(false);
    switchHandTutorial.SetActive(true);
  }
}
