using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenTutorial : MonoBehaviour {
  [Header("Initialization")]
  public ShelfDoor door;

  void Update () {
    if (door.isOpen) {
      gameObject.SetActive(false);
    }
  }
}
