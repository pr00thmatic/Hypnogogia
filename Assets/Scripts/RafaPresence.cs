using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaPresence : MonoBehaviour {
  [Header("Initialization")]
  public Transform defaultRoom;
  public Transform root;

  void Reset () {
    defaultRoom = transform.parent;
  }

  void OnEnable () {
    PresenceRequester.onPresenceRequested += HandleRequest;
    PresenceRequester.onRoomExit += HandleExit;
  }

  void OnDisable () {
    PresenceRequester.onPresenceRequested -= HandleRequest;
    PresenceRequester.onRoomExit -= HandleExit;
  }

  public void HandleRequest (PresenceRequester requester) {
    root.parent = requester.room;
  }

  public void HandleExit (PresenceRequester requester) {
    root.parent = defaultRoom;
  }
}
