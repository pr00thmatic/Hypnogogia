using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateOnEnable : MonoBehaviour {
  public GameObject[] toActivate;

  void OnEnable () {
    foreach (GameObject thing in toActivate) {
      thing.SetActive(true);
    }
  }
}
