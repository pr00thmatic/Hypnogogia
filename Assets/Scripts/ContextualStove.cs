using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualStove : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange fireScaleRange = new RandomRange(0, 1.6f);

  [Header("Initialization")]
  public Transform fire;
  public FirelyLight originalFire;

  void Update () {
    fire.transform.localScale = Vector3.one * fireScaleRange.Lerp(originalFire.value);
  }
}
