using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TinderGuy : MonoBehaviour {
  [Header("Information")]
  public List<Variant> yup = new List<Variant>();
  public List<Variant> nope = new List<Variant>();

  [Header("Initialization")]
  public Animator animator;

  public void Randomize () { StartCoroutine(_Randomize()); }
  IEnumerator _Randomize () {
    animator.SetTrigger("slide");
    if (Application.isPlaying) yield return new WaitForSeconds(0.1f);
    Variant[] variants = GetComponentsInChildren<Variant>();
    yup.Clear();
    nope.Clear();

    foreach (Variant variant in variants) {
      variant.Randomize();
      if (variant.IsOk) {
        yup.Add(variant);
      } else {
        nope.Add(variant);
      }
    }
  }

  public void BalanceIt () {
    BalanceIt(yup, nope)?.SetYup();
    BalanceIt(nope, yup)?.SetNope();
  }

  public Variant BalanceIt (List<Variant> v, List<Variant> dopleganger) {
    if (v.Count == 0) {
      int random = Random.Range(0, dopleganger.Count);
      v.Add(dopleganger[random]);
      dopleganger.RemoveAt(random);
      return v[random];
    }
    return null;
  }
}
