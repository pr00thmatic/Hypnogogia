using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaControls : MonoBehaviour {
  [Header("Information")]
  public int currentHand;
  public Vector3 CurrentHandPosition { get => handControls.transform.GetChild(currentHand).gameObject.transform.position; }

  [Header("Initialization")]
  public GameObject handControls;

  void Start () {
    SetControlTo(currentHand, true);
  }

  public void SwitchHand () {
    SetControlTo(currentHand, false);
    currentHand = (currentHand + 1) % handControls.transform.childCount;
    SetControlTo(currentHand, true);
  }

  public void SetControlTo (int handIndex, bool enabled) {
    handControls.transform.GetChild(handIndex).gameObject.SetActive(enabled);
  }
}
