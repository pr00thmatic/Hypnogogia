using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ContextualStove : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange fireScaleRange = new RandomRange(0, 1.6f);
  public bool debugClosed = false;

  [Header("Information")]
  public CookingRecipient recipient;

  [Header("Initialization")]
  public Transform recipientAnchor;
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

  public void Open (CookingRecipient requester) {
    animator.SetBool("is open", true);
    recipient = requester;
    recipient.representation.AnchorTo(recipientAnchor);
  }

  public void Open () {
    animator.SetBool("is open", true);
    HideWhatsCookin();
  }

  public void Close () {
    animator.SetBool("is open", false);
    recipient = null;
  }

  public void HideWhatsCookin () {
    foreach (Transform thing in whatsCookin) {
      thing.gameObject.SetActive(false);
    }
  }
}
