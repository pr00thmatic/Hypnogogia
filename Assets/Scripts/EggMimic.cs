using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EggMimic : MonoBehaviour {
  [Header("Configuration")]
  public EggManager original;
  public EggManager copy;

  void Update () {
    if (!original) return;
    // configuration
    copy.totallyCooked = original.totallyCooked;
    copy.startBurning = original.startBurning;
    copy.timeBetweenOilJump = original.timeBetweenOilJump;
    copy.zeroWigglesOverride = original.zeroWigglesOverride;

    // information
    copy.wigglyShines = original.wigglyShines;
    copy.cooldownToOilJump = original.cooldownToOilJump;
    copy.desirableWigglesWithCookingFactor = original.desirableWigglesWithCookingFactor;
  }
}
