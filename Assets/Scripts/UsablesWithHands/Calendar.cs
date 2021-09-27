using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class Calendar : MonoBehaviour {
  [Header("Initialization")]
  public Grabbable today;
  public GameObject now;
  public Conversation conversation;
  public ConversationData storyShort;

  void OnEnable () {
    today.onGrabbed += HandleTodayShift;
    conversation.onFinished += HandleEnd;
  }

  void OnDisable () {
    today.onGrabbed -= HandleTodayShift;
    conversation.onFinished -= HandleEnd;
  }

  public void HandleTodayShift (GrabbingHand hand) {
    now.SetActive(true);
  }

  public void HandleEnd () {
    conversation.data = storyShort;
  }
}
