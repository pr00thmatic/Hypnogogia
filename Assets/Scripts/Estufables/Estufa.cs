using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Estufa : MonoBehaviour {
  // [Header("Information")]
  public float Value { get => knob.Value; }

  [Header("Initialization")]
  public FireKnob knob;
}
