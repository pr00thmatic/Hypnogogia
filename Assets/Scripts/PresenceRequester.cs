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

  public void RequestPresence () {
    onPresenceRequested?.Invoke(this);
  }
}
