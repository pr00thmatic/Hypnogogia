using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class DefaultEnding : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 3;

  [Header("Initialization")]
  public Keyla keyla;
  public ConversationData greeting;
  public Transform initialPosition;
  public EndingTriggerer triggerer;

  void OnEnable () {
    keyla.r.sprite = keyla.officeClothes;
    keyla.motion.rootMotion.position = initialPosition.position;
    keyla.motion.target = keyla.greetRafa;
    keyla.motion.onArrive += TalkToRafa;
  }

  public void TalkToRafa () {
    keyla.conversation.StartDialogue(greeting);
    keyla.conversation.onFinished += EndOfEnding;
  }

  public void EndOfEnding () {
    keyla.conversation.onFinished -= EndOfEnding;
    GetComponent<IEnding>().TriggerEndOfEnding();
  }
}
