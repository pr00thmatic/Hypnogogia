using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StethoscopeMic : MonoBehaviour {
  [Header("Information")]
  public StethoSign currentSign;

  void OnTriggerStay2D (Collider2D c) {
    StethoSign sign = c.GetComponent<StethoSign>();
    if (!sign) return;
    RumblePatterns.intensity = 1;
    if (currentSign != sign) {
      Rumble.SetRumble(sign.pattern);
      currentSign = sign;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    StethoSign sign = c.GetComponent<StethoSign>();
    if (!sign || sign != currentSign) return;
    RumblePatterns.intensity = 0;
  }
}
