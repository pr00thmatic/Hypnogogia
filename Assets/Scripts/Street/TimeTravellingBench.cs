using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeTravellingBench : MonoBehaviour {
  [Header("Initialization")]
  public Bench bench;

  [Header("Information")]
  public float originalDayDuration;
  public float newDayDuration = 10;

  void OnEnable () {
    bench.onUse += HandleUse;
  }

  void OnDisable () {
    bench.onUse -= HandleUse;
  }

  public void HandleUse (bool isBeingUsed, SittingRafa user) {
    if (isBeingUsed) {
      originalDayDuration = Sky.Instance.dayDuration;
      Sky.Instance.dayDuration = newDayDuration;
    } else {
      Sky.Instance.dayDuration = originalDayDuration;
    }
  }
}
