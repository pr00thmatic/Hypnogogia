using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patient : MonoBehaviour {
  [Header("Configuration")]
  public ClinicalInfo info;
  public RandomColorFromArray body;
  public RandomColorFromArray hair;
  public RandomColorFromArray pants;
  public RandomColorFromArray shoes;
  public RandomIntFromArray hairStyle;

  [Header("Information")]
  public bool isRandomized = false;

  [Header("Initialization")]
  public WalkToEnfermeria walker;
  public WaitingPatient waiting;
  public GameObject interactIndicator;

  void Awake () {
    if (isRandomized) return;
    body.Randomize();
    hair.Randomize();
    pants.Randomize();
    shoes.Randomize();
    hairStyle.Randomize();
    isRandomized = true;
  }
}
