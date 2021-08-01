using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TinderGuy : MonoBehaviour {
  [Header("Information")]
  public Variant yup;
  public Variant nope;

  [Header("Initialization")]
  public PartVariant randomizer;
  public TextMeshPro dialogue;
  public Animator arm;

  void Start () {
    Randomize();
  }

  public void Randomize () { StopAllCoroutines(); StartCoroutine(_Randomize()); }
  IEnumerator _Randomize() {
    randomizer.Randomize();

    yield return null;
    CleverPick();
    StartCoroutine(_ExpressTastes());
  }

  public void CleverPick () {
    List<Variant> variants = new List<Variant>(GetComponentsInChildren<Variant>());
    Utils.Shuffle(variants);
    yup = null;
    nope = null;

    foreach (Variant variant in variants) {
      if (!yup && variant.IsOk) yup = variant;
      if (!nope && !variant.IsOk) nope = variant;
      if (yup && nope) break;
    }

    if (!nope) {
      do {
        nope = Utils.RandomPick(variants);
      } while (nope as PartVariant);
      nope.SetNope();
    }
    if (!yup) {
      do {
        yup = Utils.RandomPick(variants);
      } while (yup as PartVariant);
      yup.SetYup();
    }
  }

  IEnumerator _ExpressTastes () {
    yield return new WaitForSeconds(1);
    dialogue.text = yup.Comment.Comment;
    yield return new WaitForSeconds(3);
    dialogue.text = "";
    yield return new WaitForSeconds(0.5f);
    dialogue.text = nope.Comment.Comment;
    yield return new WaitForSeconds(3);
    arm.SetTrigger("swipe left");
    dialogue.text = "";
    yield return new WaitForSeconds(1);
    Randomize();
  }
}
