using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicRouter : NonPersistentSingleton<MusicRouter> {
  [Header("Configuration")]
  public VolumeLerper target;
  public float silenceTime = 0.5f;
  public float outTime = 0.25f;
  public float inTime = 1.5f;

  [Header("Initialization")]
  public Transform root;

  void Update () {
    foreach (Transform child in root) {
      child.GetComponent<VolumeLerper>().target = (target && target.transform == child)? 1: 0;
    }
  }

  public void SetTarget (VolumeLerper target) {
    if (this.target == target) return;
    StopAllCoroutines(); StartCoroutine(_SetTarget(target));
  }
  IEnumerator _SetTarget (VolumeLerper target) {
    this.target.speed = 1/outTime;
    this.target = null;
    yield return new WaitForSeconds(outTime + silenceTime);
    target.speaker.Stop();
    target.speaker.Play();
    target.speed = 1/inTime;
    this.target = target;
  }
}
