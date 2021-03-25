using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class MimicActive : MonoBehaviour {
  public GameObject mimo;
  public GameObject target;

  void Update () {
    mimo.SetActive(target.activeSelf);
  }
}
