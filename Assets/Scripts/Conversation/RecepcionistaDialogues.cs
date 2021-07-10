using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class RecepcionistaDialogues : MonoBehaviour {
  public event System.Action onSnitch;

  [Header("Information")]
  public int reganosCasillero = -1;
  public int reganosTarjeta = -1;
  public bool snitched = false;

  [Header("Initialization")]
  public Conversation conversation;
  public ConversationData[] casilleros;
  public ConversationData[] tarjetas;
  public UsableWithHand[] watchingLockers;
  public Grabbable[] watchingCards;
  public RecepcionistaAnimations animations;
  // public Transform debugCardFather;

  void OnEnable () { OnEnableOrDisable(true); }
  void OnDisable () { OnEnableOrDisable(false); }

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

  void Update () {
    if (snitched) return;
  //   if (!debugCardFather) return;
  //   watchingCards = debugCardFather.GetComponentsInChildren<Grabbable>();
    animations.targetEyesOrientation = 0;
    foreach (UsableWithHand casillero in watchingLockers) {
      if (casillero.canBeUsed) {
        animations.targetEyesOrientation = -1;
        break;
      }
    }
    if (animations.targetEyesOrientation == 0) {
      foreach (Grabbable card in watchingCards) {
        if (card.couldBeGrabbed) {
          animations.targetEyesOrientation = -1;
          break;
        }
      }
    }
  }

  public void Reganar (ref int counter, ConversationData[] datas) {
    if (snitched) return;
    counter++;
    conversation.data = datas[counter];
    conversation.NextDialogue();
    if (counter == datas.Length-2) animations.isUpset = true;
    if (counter == datas.Length-1) conversation.onFinished += Snitch;
  }

  public void ReganarPorCasillero () {
    Reganar(ref reganosCasillero, casilleros);
  }

  public void ReganarPorTarjeta () {
    Reganar(ref reganosTarjeta, tarjetas);
  }

  public void Snitch () {
    conversation.onFinished -= Snitch;
    snitched = true;
    animations.targetEyesOrientation = 0;
    this.enabled = false;
    onSnitch?.Invoke();
  }
}
