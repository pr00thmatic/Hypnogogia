using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DigitalClock : MonoBehaviour {
  public TextMeshPro display;

  void Update () {
    display.text = Utils.DigitalTime(Sky.Instance.hour);
  }
}
