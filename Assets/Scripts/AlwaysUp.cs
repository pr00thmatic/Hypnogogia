using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class AlwaysUp : MonoBehaviour {
  void Update () {
    transform.up = Vector3.up;
  }
}
