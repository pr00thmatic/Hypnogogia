using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualStove : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange fireScaleRange = new RandomRange(0, 1.6f);
  public float cookingTime = 3;

  [Header("Initialization")]
  public Transform fire;
  public FirelyLight originalFire;
  public EggManager egg;

  void Update () {
    fire.transform.localScale = Vector3.one * fireScaleRange.Lerp(originalFire.value);
    egg.zeroWigglesOverride = originalFire.value > 0.2f? 1: 0;
    egg.cookingFactor += (Time.deltaTime / cookingTime) * originalFire.value;
  }
}
