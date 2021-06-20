using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabTutorial : MonoBehaviour {
  [Header("Information")]
  public bool triggered = false;

  [Header("Initialization")]
  public Grabbable pan;

  void Update () {
    if (triggered) return;
    if (pan.IsGrabbed) {
      triggered = true;
      StartCoroutine(_TurnOff());
    }
  }

  IEnumerator _TurnOff () {
    yield return new WaitForSeconds(1);
    gameObject.SetActive(false);
  }
}
