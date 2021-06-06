using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Washer : MonoBehaviour {
  [Header("Initialization")]
  public Spill spill;

  void Update () {
    IWashable washable = spill.collided? spill.collided.GetComponentInParent<IWashable>(): null;
    if (washable != null) {
      washable.Wash();
    }
  }
}
