using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SittingAtEnfermeria : MonoBehaviour {
  [Header("Initialization")]
  public GameObject frontSkin;

  void OnEnable () {
    frontSkin.SetActive(true);
  }
}
