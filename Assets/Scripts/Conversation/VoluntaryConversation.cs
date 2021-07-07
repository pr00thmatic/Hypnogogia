using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
public class VoluntaryConversation : MonoBehaviour {
  // [Header("Information")]
  public bool CanStartConversation { get => talkIndicator.activeSelf; set => talkIndicator.SetActive(value); }

  [Header("Initialization")]
  public Conversation conversation;
  public GameObject talkIndicator;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Talk.performed += HandleTalk;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Talk.performed -= HandleTalk;
  }

  void OnTriggerStay2D (Collider2D c) {
    Starter starter = c.GetComponent<Starter>();
    if (!starter) return;
    CanStartConversation = true;
    talkIndicator.SetActive(!conversation.IsCurrentlyHappening);
  }

  void OnTriggerExit2D (Collider2D c) {
    if (!c.GetComponent<Starter>()) return;
    CanStartConversation = false;
    talkIndicator.SetActive(false);
  }

  public void HandleTalk (InputAction.CallbackContext ctx) {
    if (CanStartConversation) {
      conversation.NextDialogue();
    }
  }
}
}
