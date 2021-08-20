using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormSpawner : MonoBehaviour {
  [Header("Information")]
  public DeskForm taken;

  [Header("Initialization")]
  public DeskForm[] deskForms;
  public GameObject minigame;
  public StateMachine machine;
  public RafaControls controls;
  public RafaPointingArm deskArm;
  public SubmissionArea submit;

  void Reset () {
    controls = GameObject.FindObjectOfType<RafaControls>(true);
  }

  void OnEnable () {
    DeskForm.onAnyGrabbed += HandleGrab;
    machine.onStateChange += HandleStateChange;
    submit.onSubmitted += HandleSubmit;
  }

  void OnDisable () {
    DeskForm.onAnyGrabbed -= HandleGrab;
    machine.onStateChange -= HandleStateChange;
    submit.onSubmitted -= HandleSubmit;
  }

  public void HandleGrab (DeskForm deskF) {
    taken = deskF;
  }

  public void HandleStateChange (State oldState) {
    if (oldState.gameObject == minigame) {
      Grabbable grabbed = Instantiate(taken.outsideRepresentation);
      GrabbingHand hand = controls.CurrentHand.GetComponentInChildren<GrabbingHand>(true);

      grabbed.transform.position = hand.transform.position;
      grabbed.transform.rotation = hand.transform.rotation;
      grabbed.GetComponent<GrabbedFormulario>().key = taken.key;

      hand.ForceGrab(grabbed);
      taken = null;
    } else {
      Grabbable grabbed = controls.CurrentHand.GetComponentInChildren<GrabbingHand>(true).currentlyGrabbed;
      if (grabbed && grabbed.GetComponent<GrabbedFormulario>()) {
        GameObject created = Instantiate(FindDeskRepresentation(grabbed.GetComponent<GrabbedFormulario>().key));
        deskArm.Grab(created);
        created.GetComponentInParent<DeskForm>().submittable = true;
      }
    }
  }

  public GameObject FindDeskRepresentation (string key) {
    foreach (DeskForm form in deskForms) {
      if (form.key == key) return form.gameObject;
    }
    return null;
  }

  public void HandleSubmit (string formKey) {
    controls.CurrentHand.GetComponentInChildren<GrabbingHand>(true).DestroyGrabbed();
  }
}
