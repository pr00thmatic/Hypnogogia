using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class Recepcionista : MonoBehaviour {
  [Header("Information")]
  public int reganosCasillero = -1;
  public int reganosTarjeta = -1;

  [Header("Initialization")]
  public Conversation conversation;
  public ConversationData[] casilleros;
  public ConversationData[] tarjetas;
  public UsableWithHand[] watchingLockers;
  public Grabbable[] watchingCards;
  public Animator animator;
  // public Transform debugCardFather;

  void OnEnable () {
    OnEnableOrDisable(true);
  }

  void OnDisable () {
    OnEnableOrDisable(false);
  }

  // void Update () {
  //   if (!debugCardFather) return;
  //   watchingCards = debugCardFather.GetComponentsInChildren<Grabbable>();
  // }

  public void OnEnableOrDisable (bool enabled) {
    foreach (UsableWithHand casillero in watchingLockers) {
      casillero.isLocked = enabled;
      if (enabled) casillero.onLockedUse += ReganarPorCasillero;
      else casillero.onLockedUse -= ReganarPorCasillero;
    }
    foreach (Grabbable card in watchingCards) {
      card.isLocked = enabled;
      if (enabled) card.onLockedGrab += ReganarPorTarjeta;
      else card.onLockedGrab -= ReganarPorTarjeta;
    }
  }

  public void Reganar (ref int counter, ConversationData[] datas) {
    counter++;
    conversation.data = datas[counter];
    conversation.NextDialogue();
    if (counter == datas.Length-1) Snitch();
  }

  public void ReganarPorCasillero () {
    Reganar(ref reganosCasillero, casilleros);
  }

  public void ReganarPorTarjeta () {
    Reganar(ref reganosTarjeta, tarjetas);
  }

  public void Snitch () {
    gameObject.SetActive(false);
  }
}
