using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class ReceptionistaStateMachine : MonoBehaviour {
  [Header("Initialization")]
  public RecepcionistaMotion motion;
  public RecepcionistaDialogues conversation;
  public GameObject standing;
  public GameObject sitting;
  public Transform inside;
  public Transform outside;

  void OnEnable () {
    conversation.onSnitch += HandleSnitch;
  }

  void OnDisable () {
    conversation.onSnitch -= HandleSnitch;
  }

  public void HandleSnitch () {
    standing.SetActive(true);
    motion.target = inside;
  }
}
