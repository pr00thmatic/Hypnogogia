using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualIngresoForm : MonoBehaviour {
  [Header("Initialization")]
  public GameObject representation;
  public Transform slots;

  void OnEnable () {
    representation.SetActive(IngresoForm.lastGrabbed);
    if (!IngresoForm.lastGrabbed) return;
    foreach (Transform slot in slots) {
      slot.GetComponent<FormSlotRepresentation>()
        .CopyData(IngresoForm.lastGrabbed.slots.Find(slot.name).GetComponent<FormSlotRepresentation>());
    }
  }
}
