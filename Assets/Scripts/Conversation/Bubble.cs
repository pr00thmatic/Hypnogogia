using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace Conversations {
public class Bubble : MonoBehaviour {
  [Header("Configuration")]
  public int smallMaxLength = 35;
  [Header("Initialization")]
  public Animator animator;
  public TextMeshPro messageHolder;
  public GameObject small;
  public GameObject big;
  public Conversable conversable;

  void Reset () {
    conversable = GetComponentInParent<Conversable>();
  }

  void OnEnable () {
    if (conversable) conversable.onDisplayRequested += HandleRequest;
  }

  void OnDisable () {
    if (conversable) conversable.onDisplayRequested -= HandleRequest;
  }

  void Update () {
    transform.forward = Vector3.forward;
    animator.SetInteger("text length", messageHolder.text.Length);
  }

  public void DisplayText () {
    messageHolder.enabled = true;
  }

  public void HideText () {
    messageHolder.enabled = false;
  }

  public void HandleRequest () {
    if (small) small.SetActive(messageHolder.text.Length <= smallMaxLength);
    if (big) big.SetActive(messageHolder.text.Length > smallMaxLength);
  }
}
}
