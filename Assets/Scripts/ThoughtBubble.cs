using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThoughtBubble : MonoBehaviour {
  [Header("Initialization")]
  public ThoughtBubbleChildrenAnimators bubble;
  public ThoughtBubbleChildrenAnimators options;

  void OnEnable () { StartCoroutine(_OnEnable()); }
  IEnumerator _OnEnable () {
    yield return new WaitForSeconds(0.5f);
    PopIn();
  }

  public void PopIn () {
    bubble.PopIn();
    options.PopIn();
  }

  public void PopOut () {
    bubble.PopOut();
    options.PopOut();
  }

  public void Repop () { StartCoroutine(_Repop()); }
  IEnumerator _Repop () {
    PopOut();
    yield return new WaitForSeconds(1);
    PopIn();
  }
}
