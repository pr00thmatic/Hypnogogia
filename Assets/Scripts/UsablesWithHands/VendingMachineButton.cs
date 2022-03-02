using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VendingMachineButton : MonoBehaviour {
  [Header("Initialization")]
  public UsableWithHand button;
  public GameObject product;

  void OnEnable () {
    button.onUse += HandleUse;
  }

  void OnDisable () {
    button.onUse -= HandleUse;
  }

  public void HandleUse (UserHand hand) {
    GameObject bought = Instantiate(product);
    bought.SetActive(true);
    bought.transform.parent = product.transform.parent;
    // boug
  }
}
