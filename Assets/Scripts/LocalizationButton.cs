using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LocalizationButton : MonoBehaviour {
  [Header("Initialization")]
  public Image image;

  void Reset () {
    image = GetComponent<Image>();
  }

  void Update () {
    image.color = new Color(1,1,1, (Localization.selected == name? 0.3f: 0.1f));
  }

  public void Select () {
    Localization.selected = name;
  }
}
