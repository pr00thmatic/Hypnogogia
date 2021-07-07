using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
public class DialogueControlTaker : MonoBehaviour {
  [Header("Initialization")]
  public Conversation conversation;
  public GameObject controlTaker;

  void Update () {
    controlTaker.SetActive(conversation.IsCurrentlyHappening);
  }
}
}
