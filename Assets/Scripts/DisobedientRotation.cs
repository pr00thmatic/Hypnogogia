using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class DisobedientRotation : MonoBehaviour {
  void FixedUpdate () {
    transform.rotation = Quaternion.identity;
  }
}
