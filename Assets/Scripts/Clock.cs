using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Clock : MonoBehaviour {
  [Header("Initialization")]
  public Transform hours;
  public Transform minutes;

  void Update () {
    hours.transform.rotation = Quaternion.Euler(0,0, -((Sky.Instance.hour / 12) % 12) * 360);
    minutes.transform.rotation = Quaternion.Euler(0,0, -(((Sky.Instance.hour * 60) % 60) / 60f) * 360);
  }
}
