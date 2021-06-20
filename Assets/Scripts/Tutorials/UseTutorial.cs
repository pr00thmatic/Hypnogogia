using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UseTutorial : MonoBehaviour {
  [Header("Information")]
  public bool triggered = false;

  [Header("Initialization")]
  public Pan pan;
  public Grabbable grabbablePan;
  public GameObject tutorial;

  void Update () {
    if (triggered) return;
    if (grabbablePan.IsGrabbed) tutorial.SetActive(true);
    if (pan.beingUsed) {
      triggered = true;
      StartCoroutine(_TurnOff());
    }
  }

  IEnumerator _TurnOff () {
    yield return new WaitForSeconds(1);
    gameObject.SetActive(false);
  }
}
