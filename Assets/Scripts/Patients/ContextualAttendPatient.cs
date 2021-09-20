using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ContextualAttendPatient : MonoBehaviour {
  public static event System.Action<bool, Patient> onChoiseMade;

  [Header("Information")]
  public Patient attendingPatient;

  [Header("Initialization")]
  public TextMeshPro patientDialogue;
  public DecissionBubble yes;
  public DecissionBubble no;
  public ThoughtBubbleChildrenAnimators statement;
  public ContextualIngreso ingresos;
  public ControlTaker control;

  void OnEnable () {
    yes.isBlocked = false; no.isBlocked = false;
    yes.animator.PopIn(); no.animator.PopIn(); statement.PopIn();
    TheInputInstance.Rafa.Cancel.performed += HandleClose;
    yes.onDecissionMade += HandleDecission;
    no.onDecissionMade += HandleDecission;
  }

  void OnDisable () {
    TheInputInstance.Rafa.Cancel.performed -= HandleClose;
    yes.onDecissionMade -= HandleDecission;
    no.onDecissionMade -= HandleDecission;
  }

  public void OpenAt (Patient patient) {
    attendingPatient = patient;
    transform.position = patient.transform.position;
    patientDialogue.text = LocalizedComment.Get(patient.info.presentation);
    control.targetPosition.position = attendingPatient.waiting.drPosition.position;
    gameObject.SetActive(true);
  }

  public void HandleClose (InputAction.CallbackContext ctx) { Close(); }
  public void Close () {
    gameObject.SetActive(false);
  }

  public void HandleDecission (DecissionBubble decission) {
    yes.isBlocked = true;
    no.isBlocked = true;
    StartCoroutine(_HandleDecission(decission));
  }

  IEnumerator _HandleDecission (DecissionBubble decission) {
    decission.animator.PopOut();
    yield return new WaitForSeconds(0.25f);
    (decission == yes? no: yes).animator.PopOut();
    yield return new WaitForSeconds(0.25f);
    statement.PopOut();
    yield return new WaitForSeconds(0.25f);
    onChoiseMade?.Invoke(decission == yes, attendingPatient);
    Close();
    if (decission == yes) {
      ingresos.OpenAt(attendingPatient);
    }
  }
}
