using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorToRoom : MonoBehaviour {
  [Header("Initialization")]
  public DoorKnob insideDoor;
  public DoorKnob outsideDoor;
  public GameObject insideRoom;
  public GameObject outsideRoom;
  public ControlTaker control;

  void OnEnable () {
    insideDoor.usable.onUse += HandleGoInside;
    outsideDoor.usable.onUse += HandleGoOutside;
  }

  void OnDisable () {
    insideDoor.usable.onUse -= HandleGoInside;
    outsideDoor.usable.onUse -= HandleGoOutside;
  }

  public void HandleGoInside (UserHand hand) { StartCoroutine(_EnterRoom(outsideDoor, insideDoor, insideRoom)); }
  public void HandleGoOutside (UserHand hand) { StartCoroutine(_EnterRoom(insideDoor, outsideDoor, outsideRoom)); }
  IEnumerator _EnterRoom (DoorKnob outside, DoorKnob inside, GameObject room) {
    control.gameObject.SetActive(true);
    yield return new WaitForSeconds(1.5f);
    room.SetActive(true);
    inside.door.isOpen = false;
    outside.door.isOpen = true;
    yield return new WaitForSeconds(1);
    control.gameObject.SetActive(false);
    outside.door.isOpen = false;
  }
}
