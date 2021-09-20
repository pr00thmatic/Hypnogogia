using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class AttendPatient : MonoBehaviour {
  [Header("Information")]
  public Patient selected;

  [Header("Initialization")]
  public RafaControls controls;
  public ContextualAttendPatient contextual;
  public ConversationData noForm;
  public Conversation conversation;

  void OnEnable () {
    TheInputInstance.Rafa.Talk.performed += HandlePatient;
    TheInputInstance.Rafa.Use.performed += HandlePatient;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Talk.performed -= HandlePatient;
    TheInputInstance.Rafa.Use.performed -= HandlePatient;
  }

  public void HandlePatient (InputAction.CallbackContext ctx) {
    if (!selected || !selected.waiting.canBeAttended) return;

    IngameForm form = controls.CurrentHand.GetComponentInChildren<GrabbingHand>()
      .currentlyGrabbed?.GetComponentInChildren<IngameForm>();

    if (!form || form.key != FormularioKeys.ingresos) {
      conversation.StartDialogue(noForm);
      return;
    }

    contextual.OpenAt(selected);
  }

  void OnTriggerStay2D (Collider2D c) {
    if (!c.GetComponentInParent<Patient>()) return;
    Patient patient = c.GetComponentInParent<Patient>();
    if (!patient) return;
    if (!patient.waiting.canBeAttended) { patient.interactIndicator.SetActive(false); return; }
    if (!selected) { SelectPatient(patient, true); return; }
    if (Vector3.Distance(patient.waiting.transform.position, transform.position) <
        Vector3.Distance(selected.waiting.transform.position, transform.position)) SelectPatient(patient, true);
  }

  void OnTriggerExit2D (Collider2D c) {
    if (!c.GetComponentInParent<Patient>()) return;
    Patient patient = c.GetComponentInParent<Patient>();
    if (!patient) return;
    if (patient == selected) SelectPatient(patient, false);
  }

  public void SelectPatient (Patient patient, bool selected) {
    patient.interactIndicator.SetActive(selected);
    if (selected) {
      this.selected = patient;
    } else if (this.selected == patient) {
      this.selected = null;
    }
  }
}
