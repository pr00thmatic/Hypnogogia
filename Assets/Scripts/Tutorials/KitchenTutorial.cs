using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KitchenTutorial : MonoBehaviour {
  [Header("Configuration")]
  public float timeToHint = 10;

  [Header("Initialization")]
  public FireKnob[] knobs;
  public DependOnDevice activator;
  public GameObject tutorial;

  void OnEnable () {
    StartCoroutine(_WatchForStuck());
  }

  void Update () {
    foreach (FireKnob knob in knobs) {
      if (knob.Value > 0) {
        tutorial.SetActive(false);
      }
    }
  }

  IEnumerator _WatchForStuck () {
    yield return new WaitForSeconds(timeToHint);
    activator.enabled = true;
    activator.transform.Find("keyboard").gameObject.SetActive(true);
  }
}
