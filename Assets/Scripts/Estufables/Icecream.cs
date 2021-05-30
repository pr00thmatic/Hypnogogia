using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Icecream : MonoBehaviour {
  [Header("Initialization")]
  public Estufable estufable;
  public Animator animator;


  void Update () {
    if (estufable.hornilla && estufable.hornilla.IsOn) {
      animator.SetFloat("melting", Mathf.Clamp(estufable.hotness * 2, 0, 0.99f));
    }
  }
}
