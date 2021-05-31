using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pan : MonoBehaviour, IOileable {
  [Header("Information")]
  public float oil;
  public bool beingUsed = false;

  [Header("Initialization")]
  public Estufable estufable;
  public ParticleSystem steam;
  public RequireContextualStove contextualStove;
  public Transform eggPlace;
  public GameObject sidePan;
  public GameObject usingPan;
  public Grabbable grabbable;

  void OnEnable () {
    contextualStove.onHornillaEnter += HandleEnter;
    contextualStove.onHornillaExit += HandleExit;
  }

  void OnDisable () {
    contextualStove.onHornillaEnter -= HandleEnter;
    contextualStove.onHornillaExit -= HandleExit;
  }

  void Update () {
    if (grabbable.IsGrabbed) {
      beingUsed = Input.GetMouseButton(1);
    } else {
      beingUsed = false;
    }
    sidePan.SetActive(!beingUsed);
    usingPan.SetActive(beingUsed);
  }

  public void AddOil (float amount) {
    oil += amount;
  }

  public void HandleEnter (Hornilla hornilla) {
    contextualStove.Representation.GetComponent<ContextualPan>().originalPan = this;
  }

  public void HandleExit (Hornilla hornilla) {
    if (eggPlace.childCount > 0) {
      Destroy(eggPlace.GetChild(0).gameObject);
    }
    EggManager contextualEgg =
      contextualStove.Representation.GetComponent<ContextualPan>().whatsCooking
      .GetComponentInChildren<EggManager>(true);

    if (contextualEgg.gameObject.activeInHierarchy) {
      GameObject egg = contextualEgg.Clone();
      egg.transform.parent = eggPlace;
      egg.transform.localPosition = Vector3.zero;
      egg.transform.localRotation = Quaternion.identity;
      egg.transform.localScale = Vector3.one;
    }
  }

  public void Cook (string name) {
    contextualStove.Representation.GetComponent<ContextualPan>().whatsCooking.Find(name).gameObject.SetActive(true);
  }
}
