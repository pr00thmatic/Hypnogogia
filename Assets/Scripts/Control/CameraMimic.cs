using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CameraMimic : MonoBehaviour {
  [Header("Initialization")]
  public Camera toMimic;
  public Camera mimic;

  void Reset () {
    toMimic = transform.parent.GetComponentInParent<Camera>();
    mimic = GetComponent<Camera>();
  }

  void Update () {
    mimic.orthographicSize = toMimic.orthographicSize;
  }
}
