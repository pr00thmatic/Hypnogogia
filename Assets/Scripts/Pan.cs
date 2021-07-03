using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pan : MonoBehaviour, IOileable, IWashable {
  public event System.Action onWash;

  [Header("Information")]
  public float oil;
  public bool beingUsed = false;

  [Header("Initialization")]
  public Estufable estufable;
  public ParticleSystem steam;
  public CookingRecipient recipient;
  public Transform eggPlace;
  public GameObject sidePan;
  public GameObject usingPan;
  public Grabbable grabbable;
  public Animator oilSpill;

  void Update () {
    beingUsed = grabbable.IsGrabbed && TheInputInstance.Input.Rafa.Use.ReadValue<float>() > 0.1f;
    sidePan.SetActive(!beingUsed);
    usingPan.SetActive(beingUsed);
    if (oilSpill.gameObject.activeInHierarchy) oilSpill.SetFloat("t", oil);
  }

  public void AddOil (float amount) {
    oil += amount;
  }

  public void Wash () {
    onWash?.Invoke();
    oil = 0;
  }
}
