using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaControls : MonoBehaviour {
  [Header("Initialization")]
  public GameObject selectableHands;
  public GameObject handControls;

  public void RouteControlToHand (GameObject handControl) {
    selectableHands.SetActive(false);
    handControl.SetActive(true);
    handControls.SetActive(true);
  }

  public void RemoveControlFromHands () {
    selectableHands.SetActive(true);
    handControls.SetActive(false);
  }
}
