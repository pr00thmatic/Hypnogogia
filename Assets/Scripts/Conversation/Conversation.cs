using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
public class Conversation : MonoBehaviour {
  [Header("Information")]
  public bool canStartConversation = false;
  public int currentPieceOfChat = -1;
  public PieceOfChat Current {
    get => currentPieceOfChat >= 0 && currentPieceOfChat < data.chat.Length? data.chat[currentPieceOfChat]: null;
  }
  public bool IsCurrentlyHappening { get => Current != null; }

  [Header("Initialization")]
  public ConversationData data;

  void OnEnable () {
    TheInputInstance.Input.Rafa.Talk.performed += HandleTalk;
  }

  void OnDisable () {
    TheInputInstance.Input.Rafa.Talk.performed -= HandleTalk;
  }

  public void NextDialogue () {
    if (Current != null) {
      Conversables.everyone[Current.owner].Hide();
    }

    currentPieceOfChat++;

    if (Current != null) {
      Conversables.everyone[Current.owner].Display(Current.message);
    } else {
      currentPieceOfChat = -1;
    }
  }

  public void HandleTalk (InputAction.CallbackContext ctx) {
    if (IsCurrentlyHappening) NextDialogue();
  }
}
}
