using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DishwasherTutorial : MonoBehaviour {
  [Header("Configuration")]
  public float timeToHint = 10;

  [Header("Information")]
  public bool triggered = false;

  [Header("Initialization")]
  public WaterKnob knob;
  public GameObject tutorial;

  void OnEnable () {
    ContextualEgg.onStuck += HandleStuck;
  }

  void OnDisable () {
    ContextualEgg.onStuck -= HandleStuck;
  }

  void Update () {
    if (knob.value > 0) gameObject.SetActive(false);
  }

  IEnumerator _ShowTutorial () {
    yield return new WaitForSeconds(10);
    tutorial.SetActive(true);
  }

  public void HandleStuck () {
    ContextualEgg.onStuck -= HandleStuck;
    triggered = true;
    StartCoroutine(_ShowTutorial());
  }
}
