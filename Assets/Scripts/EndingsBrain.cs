using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndingsBrain : MonoBehaviour {
  [Header("Information")]
  public bool decided = false;
  public GameObject preferedEnding;

  [Header("Initialization")]
  public GameObject fire;
  public GameObject defaultEnding;
  public GameObject explossiveClinic;
  public GameObject finalCamera;
  public TriggeredByRafa explossionBuzzer;
  public TriggeredByRafa fireDecider;
  public FireKnob[] fireStarters;

  public void Subscribe (bool value) {
    if (value) explossionBuzzer.onEnter += DiscardExplossion;
    else explossionBuzzer.onEnter -= DiscardExplossion;
    if (value) fireDecider.onEnter += CheckFire;
    else fireDecider.onEnter -= CheckFire;
  }
  void OnEnable () {
    preferedEnding = explossiveClinic;
    Subscribe(true);
  }

  void Update () {
    if (decided) return;
    if (Sky.Instance.IsTheEndOfTime) {
      Decide();
    }
  }

  public void Decide () {
    Subscribe(false);
    decided = true;
    IEnding ending = preferedEnding.GetComponent<IEnding>();
    ending.TriggerEndOfEnding();
    ending.onFinished += HandleEnd;
  }

  public void HandleEnd () {
    finalCamera.SetActive(true);
  }

  public void DiscardExplossion (TriggeredByRafa trigger) {
    if (preferedEnding == explossiveClinic) preferedEnding = defaultEnding;
  }

  public void CheckFire (TriggeredByRafa trigger) {
    bool yup = false;
    foreach (FireKnob starter in fireStarters) {
      if (starter.Value >= 0.2f) {
        yup = true;
        break;
      }
    }

    if (yup) {
      preferedEnding = fire;
    } else {
      preferedEnding = defaultEnding;
    }
  }
}
