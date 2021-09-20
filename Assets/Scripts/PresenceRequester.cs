using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PresenceRequester : MonoBehaviour {
  public static event System.Action<PresenceRequester> onPresenceRequested;
  public static event System.Action<PresenceRequester> onRoomExit;

  [Header("Initialization")]
  public Transform room;

  void OnEnable () {
    RequestPresence();
  }

  void OnDisable () {
    if (!this.enabled) onRoomExit?.Invoke(this);
  }

  public void RequestPresence () {
    onPresenceRequested?.Invoke(this);
  }
}
