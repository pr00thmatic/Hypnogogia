using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualLens : MonoBehaviour {
  [Header("Information")]
  public SelectedHand currentHand;

  [Header("Initialization")]
  public Transform root;

  void Update () {
    if (currentHand && !currentHand.IsSelected) {
      currentHand = null;
      root.gameObject.SetActive(false);
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    SelectedHand hand = c.GetComponentInParent<SelectedHand>();
    if (!hand || !hand.IsSelected) return;
    currentHand = hand;
    root.position = hand.transform.position;
    root.gameObject.SetActive(true);
  }

  void OnTriggerExit2D (Collider2D c) {
    SelectedHand hand = c.GetComponentInParent<SelectedHand>();
    if (!hand || !hand.IsSelected) return;
    if (hand == currentHand) currentHand = null;
    root.gameObject.SetActive(false);
  }
}
