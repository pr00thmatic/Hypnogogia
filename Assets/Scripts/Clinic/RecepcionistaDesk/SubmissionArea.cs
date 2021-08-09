using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class SubmissionArea : MonoBehaviour {
  public event System.Action<string> onSubmitted;

  [Header("Information")]
  public DeskForm toSubmit;
  public bool CanSubmit { get => toSubmit; }
  public static int submittedForms = 0;

  [Header("Initialization")]
  public RafaPointingArm arm;
  public GameObject talkIndicator;

  void OnEnable () {
    TheInputInstance.Rafa.Talk.performed += HandleSubmission;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Talk.performed -= HandleSubmission;
  }

  void OnTriggerStay2D (Collider2D c) {
    if (c.GetComponentInParent<DeskForm>() && c.GetComponentInParent<DeskForm>().submittable) {
      toSubmit = c.GetComponentInParent<DeskForm>();
      talkIndicator.SetActive(true);
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (c.GetComponentInParent<DeskForm>() && c.GetComponentInParent<DeskForm>().submittable) {
      toSubmit = null;
      talkIndicator.SetActive(false);
    }
  }

  public void HandleSubmission (InputAction.CallbackContext ctx) {
    if (!CanSubmit || !toSubmit.submittable) return;

    onSubmitted?.Invoke(toSubmit.key);
    TheInputInstance.Rafa.Talk.performed -= HandleSubmission;
  }
}
