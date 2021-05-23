using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pan : MonoBehaviour, IOileable {
  [Header("Information")]
  public float oil;

  public void AddOil (float amount) {
    oil += amount;
  }
}
