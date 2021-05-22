using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Estufable : MonoBehaviour {
  [Header("Configuration")]
  public float cookingTimeAtMax = 8;

  [Header("Initialization")]
  public float hotness;
  public Estufa estufa;

  void Update () {
    if (estufa) {
      hotness = Mathf.Clamp(hotness + (Time.deltaTime * estufa.Value) / cookingTimeAtMax, 0, 1);
    }
  }

  void OnTriggerStay2D (Collider2D c) {
    Estufa estufa = c.GetComponentInParent<Estufa>();
    if (!estufa) return;
    this.estufa = estufa;
  }

  void OnTriggerExit2D (Collider2D c) {
    Estufa estufa = c.GetComponentInParent<Estufa>();
    if (!estufa || estufa != this.estufa) return;
    this.estufa = null;
  }
}
