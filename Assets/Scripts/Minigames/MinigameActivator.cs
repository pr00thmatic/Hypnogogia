using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class MinigameActivator : MonoBehaviour {
  // [Header("Information")]
  public bool CanInteract { get => talkIndicator.activeSelf; set => talkIndicator.SetActive(value); }

  [Header("Initialization")]
  public StateMachine machine;
  public GameObject minigame;
  public GameObject talkIndicator;

  void Awake () {
    machine.onStateChange += HandleStateChange;
  }

  void OnDestroy () {
    if (machine && this) machine.onStateChange -= HandleStateChange;
  }

  void OnTriggerStay2D (Collider2D c) {
    if (c.GetComponentInParent<Rafa>() && !CanInteract) {
      TheInputInstance.Rafa.Talk.performed += HandleTalk;
      CanInteract = true;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (c.GetComponentInParent<Rafa>() && CanInteract) {
      TheInputInstance.Rafa.Talk.performed -= HandleTalk;
      CanInteract = false;
    }
  }

  public void HandleTalk (InputAction.CallbackContext ctx) {
    if (!CanInteract) return;
    minigame.SetActive(true);
    CanInteract = false;
  }

  public void HandleStateChange (State oldState) {
    if (oldState.gameObject != this.gameObject) gameObject.SetActive(true);
  }
}
