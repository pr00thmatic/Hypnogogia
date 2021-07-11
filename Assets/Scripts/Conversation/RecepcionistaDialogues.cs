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
  public RecepcionistaAnimations animations;
  public ClinicStartRoomLocker locker;

  void OnEnable () {
    locker.onCasilleroAttempt += ReganarPorCasillero;
    locker.onCardAttempt += ReganarPorTarjeta;
  }

  void OnDisable () {
    locker.onCasilleroAttempt -= ReganarPorCasillero;
    locker.onCardAttempt -= ReganarPorTarjeta;
  }

  void Update () {
    if (snitched) return;
    animations.targetEyesOrientation = locker.isOverSuspiciousThing? -1: 0;
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
    locker.enabled = this.enabled = false;
    onSnitch?.Invoke();
  }
}
