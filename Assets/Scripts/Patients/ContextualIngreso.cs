using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualIngreso : MonoBehaviour {
  [Header("Initialization")]
  public GameObject rafa;

  void OnEnable () {
    rafa.SetActive(false);
  }

  void OnDisable () {
    rafa.SetActive(true);
  }
}
