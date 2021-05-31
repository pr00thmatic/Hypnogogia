using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequireContextualStove : MonoBehaviour {
  public event System.Action<Hornilla> onHornillaEnter;
  public event System.Action<Hornilla> onHornillaExit;

  [Header("Information")]
  public Hornilla hornilla;

  [Header("Initialization")]
  public Estufable estufable;
  public string representationName;
  public GameObject Representation {
    get => hornilla? hornilla.GetComponentInParent<CookingPlace>().WhatsCookin.Find(representationName).gameObject: null;
  }

  void OnEnable () {
    estufable.onHornillaEnter += HandleEnter;
    estufable.onHornillaExit += HandleExit;
  }

  void OnDisable () {
    estufable.onHornillaEnter -= HandleEnter;
    estufable.onHornillaExit -= HandleExit;
  }

  public void HandleEnter (Hornilla hornilla) {
    CookingPlace cookerxD = hornilla.GetComponentInParent<CookingPlace>();
    this.hornilla = hornilla;
    cookerxD.contextual.Open();
    Representation.SetActive(true);
    onHornillaEnter?.Invoke(hornilla);
  }

  public void HandleExit (Hornilla hornilla) {
    hornilla.GetComponentInParent<CookingPlace>().contextual.Close();
    if (hornilla == this.hornilla) {
      onHornillaExit?.Invoke(hornilla);
      this.hornilla = null;
    }
  }
}
