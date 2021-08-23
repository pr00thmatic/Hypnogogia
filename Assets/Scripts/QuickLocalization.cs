using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuickLocalization : MonoBehaviour {
  [Header("Configuration")]
  public LocalizedComment[] text;

  // [Header("Information")]
  public string Text {
    get {
      foreach (LocalizedComment c in text) {
        if (c.location == Localization.selected) return c.comment;
      }
      return text[0].comment;
    }
  }

  [Header("Initialization")]
  public TextMeshPro display;

  void Reset () {
    display = GetComponent<TextMeshPro>();
    text = new LocalizedComment[] { new LocalizedComment() { location = "bo", comment = display.text } };
  }

  void Update () {
    display.text = Text;
  }
}
