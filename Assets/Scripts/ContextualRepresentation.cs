using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualRepresentation : MonoBehaviour {
  [Header("Initialization")]
  public Transform originalAnchor;

  void Reset () {
    originalAnchor = transform.parent;
  }

  public void AnchorTo (Transform anchor, bool setActiveTo = true) {
    StopAllCoroutines();
    gameObject.SetActive(setActiveTo);
    transform.parent = anchor;
    transform.localPosition = Vector3.zero;
    transform.localRotation = Quaternion.identity;
    transform.localScale = Utils.SetX(transform.localScale, Mathf.Abs(transform.localScale.x));
  }

  public void Unanchor () { StartCoroutine(_Unanchor()); }
  IEnumerator _Unanchor () {
    Animator animator = transform.parent.GetComponentInParent<Animator>();
    yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime == 1);
    AnchorTo(originalAnchor, false);
  }
}
