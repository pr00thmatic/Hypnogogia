using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayAnimationOnArrive : MonoBehaviour, IGiveInstructionsOnArrive {
  [Header("Configuration")]
  public string animationName;

  [Header("Initialization")]
  public Animator animator;

  public void OnArrive () {
    animator.CrossFadeInFixedTime(animationName, 0.1f);
  }
}
