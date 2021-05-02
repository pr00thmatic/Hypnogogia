using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UncontrolOnDisable : MonoBehaviour {
  void OnDisable () {
    foreach (Transform child in transform) {
      child.gameObject.SetActive(false);
    }
  }
}
