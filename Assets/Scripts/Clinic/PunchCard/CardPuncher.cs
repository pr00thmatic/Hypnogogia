using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardPuncher : MonoBehaviour {
  [Header("Configuration")]
  public float waitingTime = 0.5f;

  [Header("Information")]
  public float cooldown = 0;
  public PunchTheCard punched;

  [Header("Initialization")]
  public GameObject inLight;
  public GameObject outLight;

  void OnDisable () {
    outLight.SetActive(true);
    cooldown = 0;
    punched = null;
  }

  void Update () {
    if (punched) {
      inLight.SetActive(true);
      return;
    }
    cooldown -= Time.deltaTime;
    inLight.SetActive(punched || cooldown > 0);
    outLight.SetActive(!inLight.activeSelf);
  }

  void OnTriggerStay2D (Collider2D c) {
    PunchTheCard card = c.GetComponent<PunchTheCard>();
    if (!card || cooldown > 0) return;

    cooldown = waitingTime;
    punched = card;
    if (!card.IsPunchedEnter) {
      card.theToday.enter.text = Utils.DigitalTime(Sky.Instance.hour);
    } else if (!card.IsPunchedExit) {
      card.theToday.exit.text = Utils.DigitalTime(Sky.Instance.hour);
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (punched == c.GetComponent<PunchTheCard>()) punched = null;
  }
}
