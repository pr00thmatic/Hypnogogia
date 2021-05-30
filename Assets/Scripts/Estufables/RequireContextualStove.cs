using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequireContextualStove : MonoBehaviour {
  public event System.Action<Hornilla> onHornillaEnter;
  public event System.Action<Hornilla> onHornillaExit;

  [Header("Initialization")]
  public Estufable estufable;
  public GameObject representation;

  void OnEnable () {
    estufable.onHornillaEnter += HandleEnter;
    estufable.onHornillaExit += HandleExit;
  }

  void OnDisable () {
    estufable.onHornillaEnter -= HandleEnter;
    estufable.onHornillaExit -= HandleExit;
  }

  public void HandleEnter (Hornilla hornilla) {
    hornilla.GetComponentInParent<CookingPlace>().contextual.Open();
    representation.SetActive(true);
    onHornillaEnter?.Invoke(hornilla);
  }

  public void HandleExit (Hornilla hornilla) {
    hornilla.GetComponentInParent<CookingPlace>().contextual.Close();
    onHornillaExit?.Invoke(hornilla);
  }
}
