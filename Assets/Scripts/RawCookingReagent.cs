using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RawCookingReagent : MonoBehaviour {
  [Header("Initialization")]
  public ContextualCookingReagent contextual;
  public GameObject root;

  void Reset () {
    root = gameObject;
    contextual = GetComponentInChildren<ContextualCookingReagent>(true);
  }

  void OnTriggerEnter2D (Collider2D c) {
    CookingRecipient recipient = c.GetComponent<CookingRecipient>();
    if (!recipient) return;
    contextual.PutIntoRecipient(recipient);
    Destroy(root);
  }
}
