using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ModifiableClock : MonoBehaviour {
  [Header("Initialization")]
  public Clock clock;
  public ClockHand minutes;
  public ClockHand hours;
  public Sky sky;

  void Update () {
    clock.enabled = !minutes.usable.beingUsed && !hours.usable.beingUsed;
    if (!clock.enabled) {
      if (hours.usable.beingUsed) {
        sky.hour = (hours.angles / 360f) * 12;
        minutes.transform.rotation = Quaternion.Euler(0,0, -(((Sky.Instance.hour * 60) % 60) / 60f) * 360);
      } else if (minutes.usable.beingUsed) {
        sky.hour = minutes.angles / 360f;
        hours.transform.rotation = Quaternion.Euler(0,0, -((Sky.Instance.hour / 12) % 12) * 360);
      }
    }
  }
}
