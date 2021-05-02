using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserHand : MonoBehaviour, IBlockHandMotion {
  [Header("Information")]
  public bool frameBlockedByInteraction = false;
  public bool Blocked { get => Time.time - enableTimestamp < 0.05f; }
  public float enableTimestamp = -1;
  public UsableWithHand currentlyUsedItem;
  public bool BlockingHandMotion { get => currentlyUsedItem && currentlyUsedItem.takesControl; }

  void OnEnable () {
    enableTimestamp = Time.time;
  }

  void Update () {
    if (Input.GetMouseButtonUp(0)) {
      frameBlockedByInteraction = false;
    }
  }
}
