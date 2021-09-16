using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormSlotRepresentation : MonoBehaviour {
  [Header("Information")]
  public string expected;
  public string obtained;

  [Header("Initialization")]
  public new SpriteRenderer renderer;

  void Reset () {
    renderer = GetComponentInChildren<SpriteRenderer>();
  }

  public void CopyData (FormSlot filled) {
    expected = filled.expected;
    obtained = filled.obtained;
    renderer.sprite = filled.handwritting.sprite;
  }
  public void CopyData (FormSlotRepresentation filled) {
    expected = filled.expected;
    obtained = filled.obtained;
    renderer.sprite = filled.renderer.sprite;
  }
}
