using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepcionistaAnimations : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange blinkingRange = new RandomRange(1, 4);
  public float targetEyesOrientation;
  public float normalizedEyesOrientationSpeed = 3;
  public bool isUpset = false;

  [Header("Information")]
  public float timeoutToBlink = 0;
  public float CurrentEyesOrientation {
    get => face.GetFloat("eyes orientation");
    set => face.SetFloat("eyes orientation", value);
  }

  [Header("Initialization")]
  public Animator face;
  public Animator legs;
  public Animator eyebrows;

  void OnEnable () {
    timeoutToBlink = Random.Range(0, blinkingRange.Max);
  }

  void Update () {
    timeoutToBlink -= Time.deltaTime;
    if (timeoutToBlink < 0) {
      timeoutToBlink = blinkingRange.Uniform;
      face.SetTrigger("blink");
    }
    CurrentEyesOrientation = Mathf.MoveTowards(CurrentEyesOrientation, targetEyesOrientation,
                                               normalizedEyesOrientationSpeed * Time.deltaTime);
    legs.SetBool("upset", isUpset);
    eyebrows.SetBool("upset", isUpset);
  }
}
