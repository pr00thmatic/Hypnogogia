using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SurfingRecepcionista : MonoBehaviour {
  [Header("Initialization")]
  public TextMeshPro dialogue;
  public Animator arm;
  public TinderGuy tinder;

  void OnEnable () {
    StartCoroutine(_SwipeItOff());
  }

  public void Randomize () {
    StopAllCoroutines();
    tinder.Randomize();
    tinder.BalanceIt();
    StartCoroutine(_ExpressTastes());
  }

  IEnumerator _ExpressTastes () {
    yield return new WaitForSeconds(1);
    if (tinder.yup.Count > 0) {
      dialogue.text = Utils.RandomPick(tinder.yup).Comment.Comment;
      yield return new WaitForSeconds(4);
      dialogue.text = "";
    }
    yield return new WaitForSeconds(0.5f);
    if (tinder.nope.Count > 0) {
      dialogue.text = Utils.RandomPick(tinder.nope).Comment.Comment;
      yield return new WaitForSeconds(4);
    }
    StartCoroutine(_SwipeItOff());
  }

  IEnumerator _SwipeItOff () {
    arm.SetTrigger("swipe left");
    dialogue.text = "";
    yield return new WaitForSeconds(0.5f);
    Randomize();
  }
}
