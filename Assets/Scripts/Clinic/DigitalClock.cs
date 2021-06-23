using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DigitalClock : MonoBehaviour {
  public TextMeshPro display;

  void Update () {
    display.text = Utils.TwoDigits((int) (Sky.Instance.hour) + "") + " : " +
      Utils.TwoDigits((int) (Sky.Instance.hour % 60) + "");
  }
}
