using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualCookingReagent : MonoBehaviour {
  public event System.Action onPutIntoRecipient;

  [Header("Information")]
  public CookingRecipient recipient;
  public float cookingTime = 3;
  [Range(0,1)]
  public float cookingFactor;
  public Hornilla Hornilla { get => recipient? recipient.hornilla: null; }

  [Header("Initialization")]
  public ContextualRepresentation representation;

  void Update () {
    if (!Hornilla) return;
    cookingFactor += (Time.deltaTime / cookingTime) * Hornilla.Value;
  }

  public void PutIntoRecipient (CookingRecipient recipient) {
    this.recipient = recipient;
    representation.originalAnchor = recipient.representation.transform;
    representation.AnchorTo(recipient.cookingAnchor);
    onPutIntoRecipient?.Invoke();
  }
}
