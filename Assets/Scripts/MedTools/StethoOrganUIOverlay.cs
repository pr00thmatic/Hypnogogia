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

  public void HandleFinding (ClinicalSign sign) {
    if (MedTools.signToBody[sign] == bodyPart) {
      animator.gameObject.SetActive(true);
    } else {
      animator.gameObject.SetActive(false);
    }
    onRumbleDisplayNeeded?.Invoke(animator);
  }

  public void HandleLoss (ClinicalSign sign) {
    if (MedTools.signToBody[sign] == bodyPart) {
      animator.gameObject.SetActive(false);
    }
    onRumbleDisplayNeeded?.Invoke(animator);
  }

}
