using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pan : MonoBehaviour, IOileable {
  [Header("Information")]
  public float oil;

  [Header("Initialization")]
  public Estufable estufable;
  public ParticleSystem steam;
  public RequireContextualStove contextualStove;

  void OnEnable () {
    contextualStove.onHornillaEnter += HandleEnter;
    contextualStove.onHornillaExit += HandleExit;
  }

  void OnDisable () {
    contextualStove.onHornillaEnter -= HandleEnter;
    contextualStove.onHornillaExit -= HandleExit;
  }

  public void AddOil (float amount) {
    oil += amount;
  }

  public void HandleEnter (Hornilla hornilla) {
    contextualStove.Representation.GetComponent<ContextualPan>().originalPan = this;
  }

  public void HandleExit (Hornilla hornilla) {

  }

  public void Cook (string name) {
    contextualStove.Representation.GetComponent<ContextualPan>().whatsCooking.Find(name).gameObject.SetActive(true);
  }
}
