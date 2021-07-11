using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class GuardiaDialogues : MonoBehaviour {
  [Header("Initialization")]
  public ClinicStartRoomLocker locker;
  public Conversation conversation;

  void OnEnable () {
    locker.onCasilleroAttempt += HandleMisbehaviour;
    locker.onCardAttempt += HandleMisbehaviour;
  }

  void OnDisable () {
    locker.onCasilleroAttempt -= HandleMisbehaviour;
    locker.onCardAttempt -= HandleMisbehaviour;
  }

  public void HandleMisbehaviour () {
    conversation.NextDialogue();
  }
}
