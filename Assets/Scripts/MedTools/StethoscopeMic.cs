using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StethoscopeMic : MonoBehaviour {
  [Header("Information")]
  public Heart currentHeart;

  void OnTriggerStay2D (Collider2D c) {
    Heart heart = c.GetComponent<Heart>();
    if (!heart) return;
    HeartRumblePatterns.intensity = 1;
    if (currentHeart != heart) {
      Rumble.SetHeartRumble(heart.pattern);
      currentHeart = heart;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    Heart heart = c.GetComponent<Heart>();
    if (!heart || heart != currentHeart) return;
    HeartRumblePatterns.intensity = 0;
  }
}
