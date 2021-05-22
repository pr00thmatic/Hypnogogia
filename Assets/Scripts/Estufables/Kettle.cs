using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Kettle : MonoBehaviour {
  [Header("Initialization")]
  public Animator hotGradient;
  public ParticleSystem steam;
  public Estufable estufable;

  void Update () {
    hotGradient.SetFloat("hotness", estufable.hotness);
    if (estufable.hotness >= 1 && estufable.estufa && !steam.isPlaying) {
      steam.Play();
    }
    if (steam.isPlaying && (!estufable.estufa || estufable.estufa.Value == 0)) {
      steam.Stop();
    }
  }
}
