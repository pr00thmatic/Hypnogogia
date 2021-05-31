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
  public EggMimic egg;

  void OnEnable () {
    contextualStove.onHornillaEnter += HandleEnter;
  }

  void OnDisable () {
    contextualStove.onHornillaEnter -= HandleEnter;
  }

  public void AddOil (float amount) {
    oil += amount;
  }

  public void HandleEnter (Hornilla hornilla) {
    contextualStove.representation.GetComponent<ContextualPan>().originalPan = this;
  }

  public void Cook (string name) {
    contextualStove.representation.GetComponent<ContextualPan>().whatsCooking.Find(name).gameObject.SetActive(true);
  }
}
