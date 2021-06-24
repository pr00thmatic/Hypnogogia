using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DisobedientScale : MonoBehaviour {
  void LateUpdate () {
    transform.localScale = Vector3.one;
  }
}
