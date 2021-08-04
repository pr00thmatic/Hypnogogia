using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class OutOfContextBubble : MonoBehaviour {
  [Header("Initialization")]
  public Animator animator;
  public TextMeshPro messageHolder;
  public GameObject small;
  public GameObject big;

  void Update () {
    animator.SetInteger("text length", messageHolder.text.Length);
  }

  public void DisplayText () {
    messageHolder.enabled = true;
  }

  public void HideText () {
    messageHolder.enabled = false;
  }
}
