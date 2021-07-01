using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CookingRecipient : MonoBehaviour {
  public event System.Action onHornillaEnter;
  public event System.Action onHornillaExit;

  [Header("Information")]
  public Hornilla hornilla;

  [Header("Initialization")]
  public ContextualRepresentation representation;
  public Grabbable grabbable;

  void Update () {
    if (grabbable.IsGrabbed && hornilla) {
      Lift();
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    if (grabbable.IsGrabbed) return;
    if (hornilla) return;
    Hornilla collided = c.GetComponent<Hornilla>();
    if (!collided || collided.bubble.recipient) return;
    Cook(collided);
  }

  void OnTriggerExit2D (Collider2D c) {
    if (!hornilla) return;
    Hornilla collided = c.GetComponent<Hornilla>();
    if (!collided || collided.bubble.recipient != this) return;
    Lift();
  }

  public void Cook (Hornilla foundHornilla) {
    hornilla = foundHornilla;
    hornilla.Open(this);
    onHornillaEnter?.Invoke();
  }

  public void Lift () {
    hornilla.Close();
    hornilla = null;
    representation.Unanchor();
    onHornillaExit?.Invoke();
  }
}
