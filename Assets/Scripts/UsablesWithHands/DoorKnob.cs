using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UsableWithHand))]
public class DoorKnob : MonoBehaviour {
  [Header("Initialization")]
  public ShelfDoor door;
  public UsableWithHand usable;

  void Reset () {
    door = GetComponentInParent<ShelfDoor>();
    usable = GetComponent<UsableWithHand>();
    usable.takesControl = false;
  }

  void OnEnable () {
    usable.onUse += Toggle;
  }

  void OnDisable () {
    usable.onUse -= Toggle;
  }

  public void Toggle (UserHand hand) {
    door.isOpen = !door.isOpen;
  }
}
