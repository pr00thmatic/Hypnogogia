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

  void OnEnable () {
    rafa.SetActive(false);
  }

  void OnDisable () {
    rafa.SetActive(true);
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
}
