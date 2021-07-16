using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class TalkingNewsGuy : MonoBehaviour {
  [Header("Configuration")]
  public bool isTalking = false;
  public float faceTime = 0.3f;

  [Header("Information")]
  public float currentCooldown;

  [Header("Initialization")]
  public Animator animator;
  public GameObject[] talkingFaces;
  public GameObject neutralFace;
  public Conversation conversation;

  void OnEnable () { StartCoroutine(_OnEnable()); }
  IEnumerator _OnEnable () {
    currentCooldown = faceTime;
    yield return new WaitForSeconds(0.5f);
    conversation.NextDialogue();
  }

  void Update () {
    isTalking = conversation.IsCurrentlyHappening;
    animator.SetBool("is talking", isTalking);
    if (isTalking) {
      currentCooldown -= Time.deltaTime;
      if (currentCooldown < 0) {
        currentCooldown = faceTime;
        GameObject pick = null; int guard = 0;
        do { pick = Utils.RandomPick(talkingFaces); guard++; } while (guard < 100 && pick.activeSelf);
        pick.SetActive(true);
      }
    } else {
      neutralFace.SetActive(true);
    }
  }
}
