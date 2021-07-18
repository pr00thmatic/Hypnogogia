using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicTriggerer : MonoBehaviour {
  [Header("Initialization")]
  public VolumeLerper target;

  void OnTriggerEnter2D (Collider2D c) {
    if (!c.GetComponent<Rafa>()) return;
    MusicRouter.Instance.SetTarget(target);
  }
}
