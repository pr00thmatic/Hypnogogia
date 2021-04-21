using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ShelfDoor : MonoBehaviour {
  [Header("Configuration")]
  public bool isOpen = false;

  [Header("Initialization")]
  public GameObject open;
  public GameObject closed;

  void Update () {
    if (open) {
      open.SetActive(isOpen);
    }
    if (closed) {
      closed.SetActive(!isOpen);
    }
  }
}
