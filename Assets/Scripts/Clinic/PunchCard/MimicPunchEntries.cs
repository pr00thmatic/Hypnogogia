using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MimicPunchEntries : MonoBehaviour {
  [Header("Initialization")]
  public SpriteRenderer copySprite;
  public Transform original;
  public Transform copy;

  void Update () {
    for (int i=0; i<original.childCount; i++) {
      PunchCardEntry originalEntry = original.GetChild(i).GetComponent<PunchCardEntry>();
      PunchCardEntry copyEntry = copy.GetChild(i).GetComponent<PunchCardEntry>();
      copyEntry.enter.text = originalEntry.enter.text;
      copyEntry.exit.text = originalEntry.exit.text;
      copyEntry.enter.enabled = copyEntry.exit.enabled = copySprite.enabled;
      originalEntry.enter.enabled = originalEntry.exit.enabled = !copySprite.enabled;
    }
  }
}
