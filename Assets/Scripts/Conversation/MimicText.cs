using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MimicText : MonoBehaviour {
  [Header("Initialization")]
  public TextMeshPro original;
  public TextMeshPro copy;

  void Update () {
    copy.enabled = original.enabled;
    copy.text = original.text;
  }
}
