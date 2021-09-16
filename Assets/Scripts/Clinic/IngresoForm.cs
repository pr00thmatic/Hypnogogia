using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngresoForm : IngameForm {
  public static IngresoForm lastGrabbed;

  // [Header("Information")]
  public bool IsGrabbed { get => grabbable.IsGrabbed; }

  [Header("Initialization")]
  public Grabbable grabbable;
  public Transform slots;

  void OnEnable () {
    ContextualIngreso.onFill += HandleFill;
    grabbable.onGrabbed += HandleGrab;
    grabbable.onDropped += HandleDrop;
  }
  void OnDisable () {
    ContextualIngreso.onFill -= HandleFill;
    grabbable.onGrabbed -= HandleGrab;
    grabbable.onDropped -= HandleDrop;
    HandleDrop();
  }

  public void HandleFill (FormSlot filled) {
    if (!IsGrabbed) return;
    slots.Find(filled.name).GetComponent<FormSlotRepresentation>()
      .CopyData(filled);
  }

  public void HandleGrab (GrabbingHand hand) { lastGrabbed = this; }
  public void HandleDrop () { if (lastGrabbed == this) lastGrabbed = null; }
}
