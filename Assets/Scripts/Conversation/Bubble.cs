using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace Conversations {
public class Bubble : MonoBehaviour {
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
    conversable.onDisplayRequested += HandleRequest;
  }

  void OnDisable () {
    conversable.onDisplayRequested -= HandleRequest;
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
    small.SetActive(messageHolder.text.Length < 8);
    big.SetActive(messageHolder.text.Length >= 8);
  }
}
}
