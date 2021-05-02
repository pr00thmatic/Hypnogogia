using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeferedChildEnabler : MonoBehaviour {
  void OnEnable () { StartCoroutine(_DeferedEnable()); }
  IEnumerator _DeferedEnable () {
    yield return null;
    foreach (Transform child in transform) {
      child.gameObject.SetActive(true);
    }
  }

  void OnDisable () {
    foreach (Transform child in transform) {
      child.gameObject.SetActive(false);
    }
  }
}
