using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// [ExecuteInEditMode]
public class ClinicStartRoomLocker : MonoBehaviour {
  public event System.Action onCasilleroAttempt;
  public event System.Action onCardAttempt;

  [Header("Initialization")]
  public UsableWithHand[] watchingLockers;
  public Grabbable[] watchingCards;
  // public Transform debugCardFather;

  [Header("Information")]
  public bool isOverSuspiciousThing = false;

  void OnEnable () { OnEnableOrDisable(true); }
  void OnDisable () { OnEnableOrDisable(false); }
  public void OnEnableOrDisable (bool enabled) {
    foreach (UsableWithHand casillero in watchingLockers) {
      casillero.isLocked = enabled;
      if (enabled) casillero.onLockedUse += TriggerCasilleroAttempt;
      else casillero.onLockedUse -= TriggerCasilleroAttempt;
    }
    foreach (Grabbable card in watchingCards) {
      card.isLocked = enabled;
      if (enabled) card.onLockedGrab += TriggerCardAttempt;
      else card.onLockedGrab -= TriggerCardAttempt;
    }
  }

  void Update () {
    // if (!debugCardFather) return;
    // watchingCards = debugCardFather.GetComponentsInChildren<Grabbable>();
    isOverSuspiciousThing = false;
    foreach (UsableWithHand casillero in watchingLockers) {
      if (casillero.canBeUsed) {
        isOverSuspiciousThing = true;
        break;
      }
    }
    if (!isOverSuspiciousThing) {
      foreach (Grabbable card in watchingCards) {
        if (card.couldBeGrabbed) {
          isOverSuspiciousThing = true;
          break;
        }
      }
    }
  }

  public void TriggerCasilleroAttempt () {
    onCasilleroAttempt?.Invoke();
  }

  public void TriggerCardAttempt () {
    onCardAttempt?.Invoke();
  }
}
