using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SittingAtEnfermeria : MonoBehaviour {
  [Header("Initialization")]
  public GameObject frontSkin;
  public Transform root;

  void OnEnable () {
    frontSkin.SetActive(true);
    root.localScale = Utils.SetX(root.localScale, Mathf.Abs(root.localScale.x));
  }
}
