using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserHand : MonoBehaviour, IBlockHandMotion {
  [Header("Information")]
  public UsableWithHand currentlyUsedItem;
  public bool BlockingHandMotion { get => currentlyUsedItem && currentlyUsedItem.takesControl; }
  public bool Blocked { get => hand.IsBlocked; }

  [Header("Initialization")]
  public SelectedHand hand;

  public void SpentAction () { hand.SpentAction(); }
}
