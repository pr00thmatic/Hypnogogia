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
  public GameObject rafa;
  public DecissionBubble yes;
  public DecissionBubble no;

  void OnEnable () {
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
    gameObject.SetActive(true);
    rafa.SetActive(false);
  }

  public void HandleClose (InputAction.CallbackContext ctx) { Close(); }
  public void Close () {
    rafa.SetActive(true);
    gameObject.SetActive(false);
  }

  public void HandleDecission (DecissionBubble decission) {
    onChoiseMade?.Invoke(decission == yes, attendingPatient);
    print(decission == yes);
    Close();
  }
}
