using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisableOutsideRotation : MonoBehaviour {
  [Header("Configuration")]
  public float angleToDisable = 70;

  [Header("Initialization")]
  public GameObject target;

  void Update () {
    target.SetActive(Vector3.Angle(transform.up, Vector3.up) > angleToDisable);
  }
}
