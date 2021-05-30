using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Estufable : MonoBehaviour {
  public event System.Action<Hornilla> onHornillaEnter;
  public event System.Action<Hornilla> onHornillaExit;

  [Header("Configuration")]
  public float cookingTimeAtMax = 8;
  public bool waitsForDrop = false;
  public bool sticksToHornilla = false;

  [Header("Initialization")]
  public float hotness;
  public Hornilla hornilla;
  public Grabbable grabbable;

  void Update () {
    if (hornilla) {
      hotness = Mathf.Clamp(hotness + (Time.deltaTime * hornilla.Value) / cookingTimeAtMax, 0, 1);
    }
    if (sticksToHornilla) {
      transform.rotation = Quaternion.identity;
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    Hornilla hornilla = c.GetComponentInParent<Hornilla>();
    if (!hornilla) return;
    if (waitsForDrop && grabbable.IsGrabbed) return;
    if (this.hornilla == hornilla) return;

    this.hornilla = hornilla;
    onHornillaEnter?.Invoke(hornilla);
  }

  void OnTriggerExit2D (Collider2D c) {
    Hornilla hornilla = c.GetComponentInParent<Hornilla>();
    if (!hornilla || hornilla != this.hornilla) return;
    this.hornilla = null;
    onHornillaExit?.Invoke(hornilla);
  }
}
