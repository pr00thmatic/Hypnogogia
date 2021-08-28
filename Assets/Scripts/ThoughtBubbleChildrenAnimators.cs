using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ThoughtBubbleChildrenAnimators : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange popOutWait = new RandomRange(0, 1f);
  public RandomRange popInWait = new RandomRange(0, 1f);
  public Color color = new Color(1,1,1,1);

  [Header("Debug")]
  public bool popOut;

  [Header("Initialization")]
  public Animator[] bubbles;
  public GameObject[] content;

  void Reset () {
    bubbles = GetComponentsInChildren<Animator>();
  }

  void OnEnable () {
    foreach (Animator bubble in bubbles) { bubble.SetTrigger("hide"); }
  }

  public void PopIn () { foreach (Animator bubble in bubbles) StartCoroutine(_PopIn(bubble)); }
  IEnumerator _PopIn (Animator bubble) {
    foreach (GameObject thing in content) thing.SetActive(false);
    yield return new WaitForSeconds(popInWait.Uniform);
    foreach (GameObject thing in content) thing.SetActive(true);
    bubble.SetBool("is visible", true);
  }

  void Update () {
    if (Application.isPlaying) {
      if (popOut) {
        popOut = false;
        PopOut();
      }
    } else {
      SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
      foreach (SpriteRenderer renderer in renderers) {
        renderer.color = color;
      }
    }
  }

  public void PopOut () { foreach (Animator bubble in bubbles) StartCoroutine(_PopOut(bubble)); }
  IEnumerator _PopOut (Animator bubble) {
    foreach (GameObject thing in content) thing.SetActive(false);
    yield return new WaitForSeconds(popOutWait.Uniform);
    bubble.SetBool("is visible", false);
  }
}
