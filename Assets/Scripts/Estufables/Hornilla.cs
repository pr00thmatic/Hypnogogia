using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hornilla : MonoBehaviour {
  // [Header("Information")]
  public float Value { get => knob.Value; }
  public bool IsOn { get => Value > 0; }

  [Header("Initialization")]
  public FireKnob knob;
  public ContextualStove bubble;

  public void Open (CookingRecipient requester) {
    bubble.Open(requester);
  }

  public void Close () {
    bubble.Close();
  }
}
