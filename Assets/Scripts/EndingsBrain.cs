using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndingsBrain : MonoBehaviour {
  [Header("Information")]
  public bool decided = false;

  [Header("Initialization")]
  public GameObject fire;
  public GameObject defaultEnding;
  public GameObject explossiveClinic;
  public GameObject finalCamera;

  void Update () {
    if (decided) return;
    if (Sky.Instance.IsTheEndOfTime) {
      Decide();
    }
  }

  public void Decide () {
    decided = true;
    IEnding ending = fire.GetComponent<IEnding>();
    ending.TriggerEndOfEnding();
    ending.onFinished += HandleEnd;
  }

  public void HandleEnd () {
    finalCamera.SetActive(true);
  }
}
