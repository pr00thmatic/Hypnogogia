using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StethoOrganUIOverlay : MonoBehaviour {
  public static event System.Action<Animator> onRumbleDisplayNeeded;

  [Header("Configuration")]
  public StethoBodyPart bodyPart;
  public Animator animator;

  void OnEnable () {
    StethoscopeMic.onSignFound += HandleFinding;
    StethoscopeMic.onSignLost += HandleLoss;
  }

  public void HandleFinding (StethoSign sign) {
    if (MedTools.signToBody[sign.pattern] == bodyPart) {
      animator.gameObject.SetActive(true);
      onRumbleDisplayNeeded?.Invoke(animator);
    } else {
      animator.gameObject.SetActive(false);
    }
  }

  public void HandleLoss (StethoSign sign) {
    if (MedTools.signToBody[sign.pattern] == bodyPart) {
      animator.gameObject.SetActive(false);
    }
  }

}
