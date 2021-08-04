using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepcionistaGrabingHand : MonoBehaviour {
  [Header("Initialization")]
  public DeskForm ingresosForm;
  public DeskForm epicrisisForm;
  public Transform handAnchor;
  public Animator animator;
  public GameObject surfing;

  [Header("Information")]
  public DeskForm currentlyGrabbing;

  public void SpawnIngresos () {
    Spawn(ingresosForm);
  }

  public void SpawnEpicrisis () {
    Spawn(epicrisisForm);
  }

  public void Spawn(DeskForm form) {
    currentlyGrabbing = Instantiate(form);
    currentlyGrabbing.transform.parent = handAnchor;
    currentlyGrabbing.transform.position = form.transform.position;
    currentlyGrabbing.blocked = false;
    currentlyGrabbing.onGrab += Release;
  }

  public void Release () {
    animator.SetTrigger("release");
    currentlyGrabbing.onGrab -= Release;
    currentlyGrabbing = null;
    surfing.SetActive(true);
  }
}
