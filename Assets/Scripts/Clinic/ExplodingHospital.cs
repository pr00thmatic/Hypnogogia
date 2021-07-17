using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class ExplodingHospital : MonoBehaviour {
  [Header("Configuration")]
  public float freakedOutSpeed = 6;
  public float tvSpeed = 4;

  [Header("Information")]
  public float originalSpeed;

  [Header("Initialization")]
  public Keyla keyla;
  public Transform tvPlace;
  public ConversationData greetings;
  public GameObject tv;
  public Conversation tvGuy;

  void OnEnable () {
    keyla.motion.target = keyla.greetRafa;
    keyla.motion.onArrive += TalkToRafa;
    originalSpeed = keyla.motion.speed;
    keyla.motion.speed = freakedOutSpeed;
  }

  public void TalkToRafa () {
    keyla.motion.onArrive -= TalkToRafa;
    keyla.conversation.StartDialogue(greetings);
    keyla.animator.CrossFadeInFixedTime("R U NOOOOTZ", 0.1f);
    keyla.conversation.onFinished += WalkToTv;
  }

  public void WalkToTv () {
    keyla.motion.speed = originalSpeed;
    keyla.conversation.onFinished -= TurnTvOn;
    keyla.motion.speed = tvSpeed;
    keyla.motion.target = tvPlace;
    keyla.motion.onArrive += TurnTvOn;
  }

  public void TurnTvOn () { StartCoroutine(_TurnTvOn()); }
  IEnumerator _TurnTvOn () {
    yield return new WaitForSeconds(0.5f);
    tv.SetActive(true);
    tvGuy.onFinished += EndOfEnding;
  }

  public void EndOfEnding () {
    tvGuy.onFinished -= EndOfEnding;
    GetComponent<IEnding>().TriggerEndOfEnding();
  }
}
