using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Clouds : MonoBehaviour {
  [Header("Initialization")]
  public Renderer r;

  void Reset () {
    r = GetComponent<Renderer>();
  }

  void Update () {
    r.sharedMaterial.SetFloat("Daytime", Sky.Instance.hour);
  }
}
