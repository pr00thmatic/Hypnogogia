using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FireKnob : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 1;
  public Vector2 angles = new Vector2(-168.12f, -23);

  [Header("Initialization")]
  public FirelyLightsController fire;
  public UsableWithHand knob;
  public Transform knobSprite;

  void Update () {
    if (knob.beingUsed) {
      fire.value = Mathf.Clamp(fire.value + Input.GetAxis("Mouse Y") * speed, 0, 1);
    }
    if (knobSprite) {
      knobSprite.rotation = Quaternion.Euler(0,0, Mathf.Lerp(angles.y, angles.x, fire.value));
    }
  }
}
