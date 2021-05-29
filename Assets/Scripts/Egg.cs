using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Egg : MonoBehaviour {
  [Header("Configuration")]
  [Range(0,1)]
  public float wigglyShines = 0;
  [Range(0,1)]
  public float status = 0;
  [Range(0,1)]
  public float alpha;

  [Header("Initialization")]
  public SpriteRenderer[] renderers;
  public Shine[] shines;
  public Animator gravitating;

  void Reset () {
    renderers = GetComponentsInChildren<SpriteRenderer>();
    shines = GetComponentsInChildren<Shine>();
    gravitating = GetComponent<Animator>();
  }

  void Update () {
    foreach (Shine shine in shines) {
      shine.animator.SetFloat("wiggly", wigglyShines);
    }

    foreach (SpriteRenderer renderer in renderers) {
      renderer.color = new Color(1,1,1, alpha);
    }

    gravitating.SetFloat("status", status);
  }
}
