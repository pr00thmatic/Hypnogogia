using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualIngreso : MonoBehaviour {
  [Header("Information")]
  public Patient attendingPatient;

  [Header("Initialization")]
  public GameObject rafa;
  public FormSlot apellidos;
  public FormSlot nombre;
  public FormSlot causa;
  public FormSlot conciencia;
  public MultipleChoise choises;
  public GameObject signature;
  public Animator form;

  void OnEnable () {
    rafa.SetActive(false);
    choises.onDone += HandleDone;
    form.SetTrigger("hide");
    form.SetBool("is visible", true);
  }

  void OnDisable () {
    if (rafa) rafa.SetActive(true);
    choises.onDone -= HandleDone;
  }

  public void OpenAt (Patient patient) {
    attendingPatient = patient;
    apellidos.expected = patient.info.apellidos;
    nombre.expected = patient.info.nombre;
    causa.expected = patient.info.cause;
    conciencia.expected = patient.info.consciousness.ToString();
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
}
