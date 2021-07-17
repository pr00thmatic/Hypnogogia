using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeTriggeredEnding : MonoBehaviour, IEnding {
  public event System.Action onFinished;

  [Header("Initialization")]
  public EndingTriggerer triggerer;

  public void TriggerEnding () {
    triggerer.ending = transform;
  }

  public void TriggerEndOfEnding () {
    onFinished?.Invoke();
  }
}
