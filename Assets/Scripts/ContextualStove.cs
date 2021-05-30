using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ContextualStove : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange fireScaleRange = new RandomRange(0, 1.6f);
  public bool debugClosed = false;

  [Header("Initialization")]
  public Transform fire;
  public FirelyLight originalFire;
  public Transform bubble;
  public Animator animator;
  public Transform whatsCookin;

  void Update () {
    if (!Application.isPlaying) {
      bubble.localScale = debugClosed? Vector3.zero: Vector3.one;
    } else {
      fire.transform.localScale = Vector3.one * fireScaleRange.Lerp(originalFire.value);
    }
  }

  public void Open () {
    animator.SetBool("is open", true);
  }

  public void Close () {
    animator.SetBool("is open", false);
  }

  public void HideWhatsCookin () {
    foreach (Transform thing in whatsCookin) {
      thing.gameObject.SetActive(false);
    }
  }
}
