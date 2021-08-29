using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class Patient : MonoBehaviour {
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
  }
}
