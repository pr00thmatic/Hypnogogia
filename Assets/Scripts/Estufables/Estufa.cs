using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Estufa : MonoBehaviour {
  // [Header("Information")]
  public float Value { get => knob.Value; }
  public bool IsOn { get => Value > 0; }

  [Header("Initialization")]
  public FireKnob knob;
}
