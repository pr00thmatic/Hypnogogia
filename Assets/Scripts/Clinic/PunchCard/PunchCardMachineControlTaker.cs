using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PunchCardMachineControlTaker : MonoBehaviour {
  [Header("Information")]
  public PunchCardControlTakerSensor current;
  public Rafa rafa;
  public HandControl hand;
  public bool CanBeUsed { get => actionIndicator.activeSelf; set => actionIndicator.SetActive(value); }
  public bool subscribed = false;

  [Header("Initialization")]
  public ControlTaker taker;
  public Transform rafaSpot;
  public Transform handTarget;
  public Transform upper;
  public Transform lower;
  public GameObject cardPuncher;
  public Collider2D cardSensor;
  public new GameObject camera;
  public GameObject actionIndicator;

  void OnEnable () {
  }

  void OnDisable () {
  }

  void OnTriggerStay2D (Collider2D c) {
    if (taker.gameObject.activeSelf) return;
    PunchCardControlTakerSensor found = c.GetComponent<PunchCardControlTakerSensor>();
    if (!found) return;
    if (current && found != current) return;
    current = found;
    Rafa rafa = c.GetComponentInParent<Rafa>();
    if (!rafa) return;
    CanBeUsed = !rafa.controls.motion.IsDucking;
    if (!subscribed) {
      subscribed = true;
      TheInputInstance.Rafa.Interact.performed += HandlePunchCardUse;
    }
  }

  void OnTriggerExit2D (Collider2D c) {
    if (taker.gameObject.activeSelf) return;
    PunchCardControlTakerSensor found = c.GetComponent<PunchCardControlTakerSensor>();
    if (found) {
      CanBeUsed = false;
      subscribed = false;
      TheInputInstance.Rafa.Interact.performed -= HandlePunchCardUse;
      if (found == current) current = null;
    }
  }

  IEnumerator _PunchCard () {
    hand = rafa.controls.CurrentHand.GetComponentInChildren<HandControl>(true);
    yield return StartCoroutine(_GetReadyToControl());
    yield return new WaitForSeconds(0.5f); // camera transition: player aknowledge the control exchange
    yield return StartCoroutine(_Control());
    CeaseControl();
    // yield return new WaitForSeconds(1);
    cardSensor.enabled = true;
  }

  public void Stop () {
    taker.gameObject.SetActive(false);
    cardPuncher.SetActive(false);
    cardSensor.enabled = true;
    StopAllCoroutines();
  }

  IEnumerator _GetReadyToControl () {
    actionIndicator.SetActive(false);
    camera.SetActive(false);
    rafa.motion.orientation = 1;
    rafa.motion.UpdateOrientation();
    cardSensor.enabled = false;
    cardPuncher.SetActive(false);
    hand.metaRig.followCommands = true;
    handTarget.position = Utils.SetZ(handTarget.position, hand.motionTarget.position.z);
    upper.position = Utils.SetZ(upper.position, hand.motionTarget.position.z);
    lower.position = Utils.SetZ(lower.position, hand.motionTarget.position.z);
    rafaSpot.position = Utils.SetZ(rafaSpot.position, rafa.motion.motionTarget.position.z);

    while (rafa.motion.motionTarget.position.x != rafaSpot.position.x &&
           hand.motionTarget.position != handTarget.position) {
      hand.motionTarget.position =
        Vector3.MoveTowards(hand.motionTarget.position, handTarget.position, 3 * Time.deltaTime);
      rafa.motion.motionTarget.position =
        Vector3.MoveTowards(rafa.motion.motionTarget.position, rafaSpot.position, rafa.motion.speed * Time.deltaTime);
      yield return null;
    }
    hand.motionTarget.position = handTarget.position;
    rafa.motion.motionTarget.position = rafaSpot.position;

    camera.SetActive(true);
  }

  IEnumerator _Control () {
    bool exit = false;
    while (!exit) {
      camera.SetActive(true);
      cardPuncher.SetActive(true);
      while (hand.motionTarget.position.y < upper.position.y) {
        float deltaMotion = TheInputInstance.Rafa.MoveHand.ReadValue<Vector2>().y * Time.deltaTime;

        if (hand.motionTarget.position.y < lower.position.y) hand.motionTarget.position = lower.position;

        // hand not trying to get lower than the lower allowed
        if (!(hand.motionTarget.position.y <= lower.position.y && deltaMotion < 0)) {
          hand.MoveTo(hand.motionTarget.position + deltaMotion * Vector3.up);
        }
        yield return null;
      }
      Grabbable grabbable = current.GetComponentInParent<Grabbable>();
      // yield return new WaitUntil(() => !grabbable.IsGrabbed);

      float elapsed = 0;
      bool cancel = false;
      exit = true;
      while (elapsed < 0.5f && !cancel) {
        camera.SetActive(false);
        elapsed += Time.deltaTime;
        float deltaMotion = TheInputInstance.Rafa.MoveHand.ReadValue<Vector2>().y * Time.deltaTime;
        cancel = deltaMotion < 0;
        if (cancel) {
          hand.MoveTo(hand.motionTarget.position + deltaMotion * Vector3.up);
          exit = false;
        }
        yield return null;
      }
    }
  }

  public void CeaseControl () {
    taker.gameObject.SetActive(false);
    cardPuncher.SetActive(false);
    current = null;
  }

  public void HandlePunchCardUse (InputAction.CallbackContext ctx) {
    Rafa rafa = current.GetComponentInParent<Rafa>();
    if (rafa.controls.motion.IsDucking) return;
    Stop();
    this.rafa = rafa;
    taker.gameObject.SetActive(true);
    StartCoroutine(_PunchCard());
  }
}
