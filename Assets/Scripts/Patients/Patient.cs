using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class Patient : MonoBehaviour {
  [Header("Configuration")]
  public float walkingSpeed = 2;
  public bool canBeAttended;

  [Header("Information")]
  public bool isRandomized = false;
  public float speed = 0;

  [Header("Initialization")]
  public ClinicalInfo info;
  public GameObject interactIndicator;
  public RandomColorFromArray body;
  public RandomColorFromArray hair;
  public RandomColorFromArray pants;
  public RandomColorFromArray shoes;
  public RandomIntFromArray hairStyle;
  public SideSkin side;
  public FrontSkin front;
  public GameObject skins;
  public Transform drPosition;

  [Header("Debug")]
  public bool go = false;

  void OnEnable () {
    body.Randomize();
    hair.Randomize();
    pants.Randomize();
    shoes.Randomize();
    hairStyle.Randomize();
    isRandomized = true;
  }

  void Update () {
    if (!side.gameObject.activeSelf && speed > 0) side.gameObject.SetActive(true);
    if (go) {
      go = false;
      GoToEnfermeria();
    }
  }

  public void GoToEnfermeria () { StartCoroutine(_GoToEnfermeria()); } IEnumerator _GoToEnfermeria () {
    canBeAttended = false;
    PatientsManager manager = GetComponentInParent<PatientsManager>();
    speed = 1;

    while (transform.position.x != manager.enfermeriaTarget.position.x) {
      transform.position =
        Utils.SetX(transform.position, Mathf.MoveTowards(transform.position.x, manager.enfermeriaTarget.position.x,
                                                         walkingSpeed * Time.deltaTime));
      yield return null;
    }

    manager.enfermeriaDoor.isOpen = true;
    speed = 0;
    yield return new WaitForSeconds(1);
    skins.SetActive(false);
    yield return new WaitForSeconds(0.25f);
    manager.enfermeriaDoor.isOpen = false;
    gameObject.SetActive(false);
  }
}
