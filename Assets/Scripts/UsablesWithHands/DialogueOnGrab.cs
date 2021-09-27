using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class DialogueOnGrab : MonoBehaviour {
  [Header("Initialization")]
  public Conversation conversation;
  public Grabbable grabbable;

  void OnEnable () {
    grabbable.onLockedGrab += HandleGrabTry;
  }

  void OnDisable () {
    grabbable.onLockedGrab -= HandleGrabTry;
  }

  public void HandleGrabTry () {
    conversation.StartDialogue();
  }
}
