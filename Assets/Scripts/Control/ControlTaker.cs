using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlTaker : MonoBehaviour {
  public static event System.Action<ControlTaker> onControlRequested;
  public static event System.Action<ControlTaker> onControlResumed;

  void OnEnable () {
    onControlRequested?.Invoke(this);
  }

  void OnDisable () {
    onControlResumed?.Invoke(this);
  }
}
