using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Conversations;

public class FireEnding : MonoBehaviour, IEnding {
  public event System.Action onFinished;

  [Header("Information")]
  public bool fired = false;

  [Header("Initialization")]
  public Keyla keyla;
  public ConversationData greeting;
  public Transform initialPosition;
  public Conversation sam;
  public GameObject cam;
  public GameObject keylaCam;

  void OnEnable () {
    keyla.standing.SetActive(true);
    keyla.r.sprite = keyla.officeClothes;
    keyla.transform.position = initialPosition.position;
    keyla.transform.rotation = initialPosition.rotation;
  }

  void OnTriggerEnter2D (Collider2D c) {
    if (fired || !c.GetComponent<Rafa>()) return;
    fired = true;
    sam.NextDialogue();
    sam.onFinished += HandleFinish;
    cam.SetActive(true);
  }

  public void HandleFinish () {
    sam.onFinished -= HandleFinish;
    keyla.motion.target = keyla.greetRafa;
    keyla.motion.onArrive += HandleArrive;
    keylaCam.SetActive(true);
  }

  public void HandleArrive () {
    keyla.motion.onArrive -= HandleArrive;
    keyla.conversation.StartDialogue(greeting);
    keyla.conversation.onNextDialogue += HandlePieceOfChat;
    keyla.conversation.onFinished += HandleEnd;
  }

  public void HandlePieceOfChat (PieceOfChat chat) {
    if (chat != null && chat.owner == "Samuel") {
      cam.SetActive(false);
      cam.SetActive(true);
    } else {
      keylaCam.SetActive(false);
      keylaCam.SetActive(true);
    }
  }

  public void HandleEnd () {
    keyla.conversation.onNextDialogue -= HandlePieceOfChat;
    keyla.conversation.onFinished -= HandleEnd;
    TriggerEndOfEnding();
  }

  public void TriggerEnding () {
    gameObject.SetActive(true);
  }

  public void TriggerEndOfEnding () {
    onFinished?.Invoke();
  }
}
