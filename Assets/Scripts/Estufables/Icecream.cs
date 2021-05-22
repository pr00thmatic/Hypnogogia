using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Icecream : MonoBehaviour {
  [Header("Initialization")]
  public Estufable estufable;
  public Animator animator;


  void Update () {
    if (estufable.estufa && estufable.estufa.IsOn) {
      animator.SetFloat("melting", Mathf.Clamp(estufable.hotness * 2, 0, 0.99f));
    }
  }
}
