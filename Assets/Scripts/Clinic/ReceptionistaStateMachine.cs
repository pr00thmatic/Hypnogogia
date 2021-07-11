using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class ReceptionistaStateMachine : MonoBehaviour {
  [Header("Initialization")]
  public TargetedMotion motion;
  public RecepcionistaDialogues conversation;
  public GameObject standing;
  public GameObject sitting;
  public Transform inside;
  public Transform outside;
  public GameObject guardia;

  void OnEnable () {
    conversation.onSnitch += HandleSnitch;
  }

  void OnDisable () {
    conversation.onSnitch -= HandleSnitch;
  }

  public void HandleSnitch () {
    standing.SetActive(true);
    motion.target = inside;
    motion.onArrive += HandleArriveGuardia;
  }

  public void HandleArriveGuardia () {
    motion.onArrive -= HandleArriveGuardia;
    guardia.SetActive(true);
    StartCoroutine(_EventuallyReturn());
  }
  IEnumerator _EventuallyReturn () {
    yield return new WaitForSeconds(0.5f);
    motion.target = outside;
    motion.onArrive += HandleReturn;
  }

  public void HandleReturn () {
    motion.onArrive -= HandleReturn;
    StartCoroutine(_EventuallySit());
  }
  IEnumerator _EventuallySit () {
    yield return new WaitForSeconds(1.5f);
    motion.rootMotion.rotation = Quaternion.Euler(0,0,0);
    sitting.SetActive(true);
  }
}
