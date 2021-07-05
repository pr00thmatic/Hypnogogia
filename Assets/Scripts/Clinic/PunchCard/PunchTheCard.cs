using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PunchTheCard : MonoBehaviour {
  // [Header("Information")]
  public bool IsPunchedEnter { get => theToday.enter.text != ""; }
  public bool IsPunchedExit { get => theToday.exit.text != ""; }

  [Header("Initialization")]
  public PunchCardEntry theToday;
}
