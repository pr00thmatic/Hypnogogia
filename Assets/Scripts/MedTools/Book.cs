using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Book : MonoBehaviour {
  [Header("Information")]
  public GrabbableTab selected;

  [Header("Initialization")]
  public Grabbable closedBook;
  public GrabbableTab guts;
  public GrabbableTab heart;

  void OnEnable () {
    closedBook.onLockedGrab += HandleOpen;
    guts.tab.onLockedGrab += HandleGuts;
    heart.tab.onLockedGrab += HandleHeart;
  }

  void OnDisable () {
    closedBook.onLockedGrab -= HandleOpen;
    guts.tab.onLockedGrab -= HandleGuts;
    heart.tab.onLockedGrab -= HandleHeart;
  }

  public void HandleOpen () {
    selected.page.SetActive(true);
  }

  public void HandleGuts () {
    guts.page.SetActive(true);
  }

  public void HandleHeart () {
    heart.page.SetActive(true);
  }
}
