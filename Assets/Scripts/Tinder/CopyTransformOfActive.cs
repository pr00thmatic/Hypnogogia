using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CopyTransformOfActive : MonoBehaviour {
  [Header("Initialization")]
  public Transform[] originals;

  void Update () {
    foreach (Transform original in originals) {
      if (original.gameObject.activeInHierarchy) {
        Utils.CopyTransform(original, transform);
      }
    }
  }
}
