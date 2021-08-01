using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Variant : MonoBehaviour {
  [Header("Configuration")]
  public int prefered;
  public TinderGuyComment[] comments;

  [Header("Information")]
  public int chosen;
  public bool IsOk { get => chosen == prefered; }
  public TinderGuyComment Comment { get => comments[chosen]; }

  public abstract void Set ();

  void OnEnable () {
    Randomize();
  }

  public void Randomize () {
    chosen = Random.Range(0, comments.Length);
    Set();
  }

  public void SetNope () {
    int guard = 1000;
    int chosen;
    do {
      chosen = Random.Range(0, comments.Length);
    } while (chosen == prefered && guard-- > 0);

    if (guard <= 0) {
      Debug.Log("OH NO!!", this);
    }

    Set();
  }

  public void SetYup () {
    chosen = prefered;
    Set();
  }
}
