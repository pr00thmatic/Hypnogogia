using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Kettle : MonoBehaviour {
  [Header("Configuration")]
  public float timeToBoilAtMax;

  [Header("Information")]
  public float hotness;
  public Estufa estufa;

  [Header("Initialization")]
  public Animator hotGradient;
  public ParticleSystem steam;

  void Update () {
    if (estufa) {
      hotness = Mathf.Clamp(hotness + (Time.deltaTime * estufa.Value) / timeToBoilAtMax, 0, 1);
    }
    hotGradient.SetFloat("hotness", hotness);
    if (hotness >= 1 && estufa && !steam.isPlaying) {
      steam.Play();
    }
    if (steam.isPlaying && (!estufa || estufa.Value == 0)) {
      steam.Stop();
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
