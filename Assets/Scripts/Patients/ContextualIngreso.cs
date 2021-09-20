using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualIngreso : MonoBehaviour {
  public static event System.Action<FormSlot> onFill;

  [Header("Information")]
  public Patient attendingPatient;

  [Header("Initialization")]
  public Transform slots;
  public MultipleChoise choises;
  public GameObject signature;
  public Animator form;

  void OnEnable () {
    choises.onDone += HandleDone;
    form.SetTrigger("hide");
    form.SetBool("is visible", true);
    foreach (Transform slot in slots) slot.GetComponent<FormSlot>().onFill += HandleFill;
  }

  void OnDisable () {
    choises.onDone -= HandleDone;
    attendingPatient.waiting.GoToEnfermeria();
    foreach (Transform slot in slots) slot.GetComponent<FormSlot>().onFill -= HandleFill;
  }

  public void OpenAt (Patient patient) {
    attendingPatient = patient;
    slots.Find("apellidos").GetComponent<FormSlot>().expected = patient.info.apellidos;
    slots.Find("nombre").GetComponent<FormSlot>().expected = patient.info.nombre;
    slots.Find("causa").GetComponent<FormSlot>().expected = patient.info.cause;
    slots.Find("conciencia").GetComponent<FormSlot>().expected = patient.info.consciousness.ToString();
    transform.position = patient.transform.position;
    gameObject.SetActive(true);
  }

  public void HandleDone () { StartCoroutine(_Done()); }
  IEnumerator _Done () {
    signature.SetActive(true);
    yield return new WaitForSeconds(1);
    form.SetBool("is visible", false);
    yield return new WaitForSeconds(0.5f);
    gameObject.SetActive(false);
  }

  public void HandleFill (FormSlot filled) { onFill?.Invoke(filled); }
}
