using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RouteWhileRafasIn : MonoBehaviour {
  [Header("Configuration")]
  public float waitBeforeOut = 0.2f;

  [Header("Information")]
  public float timeWithoutRafa = 0;

  [Header("Initialization")]
  public GameObject whileOut;
  public GameObject whileIn;

  void Update () {
    if (whileOut.activeSelf) return;

    timeWithoutRafa += Time.deltaTime;
    if (timeWithoutRafa > waitBeforeOut) {
      whileOut.SetActive(true);
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    if (!c.GetComponentInParent<Rafa>()) return;
    whileIn.SetActive(true);
    timeWithoutRafa = 0;
  }
}
