using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserHand : MonoBehaviour, IBlockHandMotion {
  [Header("Information")]
  public bool blockedByInteraction = false;
  public bool blockedByEnable;
  public bool Blocked { get => blockedByEnable || blockedByInteraction; }
  public UsableWithHand currentlyUsedItem;
  public bool BlockingHandMotion { get => currentlyUsedItem && currentlyUsedItem.takesControl; }

  void OnEnable () {
    blockedByEnable = true;
  }

  void Update () {
    if (Input.GetMouseButtonUp(0)) {
      blockedByEnable = blockedByInteraction = false;
    }
  }
}
