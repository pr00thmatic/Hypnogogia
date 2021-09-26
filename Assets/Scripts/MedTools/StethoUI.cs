using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StethoUI : NonPersistentSingleton<StethoUI> {
  [Header("Initialization")]
  public Transform locations;
  public Animator animator;

  void OnEnable () {
    StethoscopeMic.onStatusChange += HandleChange;
  }

  void OnDisable () {
    StethoscopeMic.onStatusChange -= HandleChange;
  }

  // void Update () {
  //   animator.SetBool("is visible", StethoscopeMic.isGrabbed);
  //   animator.SetBool("sign found", StethoscopeMic.signFound);
  // }

  public void HandleChange (StethoscopeMic mic) {
    animator.SetBool("is visible", mic.isGrabbed);
    animator.SetBool("sign found", mic.currentSign);
  }
}
