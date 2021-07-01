using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pan : MonoBehaviour, IOileable, IWashable {
  [Header("Information")]
  public float oil;
  public bool beingUsed = false;
  public bool somethingIsStuck = false;

  [Header("Initialization")]
  public Estufable estufable;
  public ParticleSystem steam;
  public CookingRecipient recipient;
  public Transform eggPlace;
  public GameObject sidePan;
  public GameObject usingPan;
  public Grabbable grabbable;

  void OnEnable () {
    recipient.onHornillaEnter += HandleEnter;
    recipient.onHornillaExit += HandleExit;
  }

  void OnDisable () {
    recipient.onHornillaEnter -= HandleEnter;
    recipient.onHornillaExit -= HandleExit;
  }

  void Update () {
    if (grabbable.IsGrabbed) {
      beingUsed = TheInputInstance.Input.Rafa.Use.ReadValue<float>() > 0.1f;
    } else {
      beingUsed = false;
    }
    sidePan.SetActive(!beingUsed);
    usingPan.SetActive(beingUsed);
  }

  public void AddOil (float amount) {
    oil += amount;
  }

  public void HandleEnter () {
    // recipient.representation.GetComponentInChildren<EggManager>(true).Mimic(eggPlace.GetComponentInChildren<CookedEggInPan>());
  }

  public void HandleExit () {
    // DestroyEgg();
    // EggManager contextualEgg =
    //   contextualStove.Representation.GetComponent<ContextualPan>().whatsCookin
    //   .GetComponentInChildren<EggManager>(true);

    // if (contextualEgg.gameObject.activeInHierarchy) {
    //   GameObject egg = contextualEgg.Clone();
    //   egg.transform.parent = eggPlace;
    //   egg.transform.localPosition = Vector3.zero;
    //   egg.transform.localRotation = Quaternion.identity;
    //   egg.transform.localScale = Vector3.one;
    // }
  }

  public void DestroyEgg () {
    if (eggPlace.childCount > 0) {
      Destroy(eggPlace.GetChild(0).gameObject);
    }
  }

  public void Wash () {
    DestroyEgg();
    oil = 0;
  }
}
