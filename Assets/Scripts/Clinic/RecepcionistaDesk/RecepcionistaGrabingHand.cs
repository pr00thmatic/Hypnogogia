using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepcionistaGrabingHand : MonoBehaviour {
  public event System.Action<string> onFormDelivery;
  public event System.Action<string> onFormSubmitted; // TODO!

  [Header("Information")]
  public DeskForm currentlyGrabbing;
  public string lastFormHanded = "";
  public Transform submittedForm;

  [Header("Initialization")]
  public SubmissionArea submit;
  public DeskForm ingresosForm;
  public DeskForm epicrisisForm;
  public Transform handAnchor;
  public Animator animator;
  public GameObject give;
  public GameObject guard;
  public GameObject surf;
  public OutOfContextBubble bubble;
  public CommentWithKey[] cantTouchIt;
  public CommentWithKey[] alreadyGiving;
  public RafaPointingArm arm;
  public Transform submittedAnchor;

  void OnEnable () {
    surf.SetActive(true);
    lastFormHanded = "";
    submit.onSubmitted += HandleSubmission;
  }

  void OnDisable () {
    submit.onSubmitted -= HandleSubmission;
  }

  public bool HandForm (string form) {
    if (give.activeSelf) { Reject(Find(alreadyGiving, form)); return false; }
    if (!FormulariosManager.Instance.CanHas(form)) { Reject(FormulariosManager.Instance.commentOnAsking[form]); return false; }
    lastFormHanded = form;
    animator.SetTrigger("hand " + form);
    give.SetActive(true);
    return true;
  }

  public void SpawnIngresos () { Spawn(ingresosForm); }
  public void SpawnEpicrisis () { Spawn(epicrisisForm); }
  public void Spawn(DeskForm form) {
    currentlyGrabbing = Instantiate(form);
    currentlyGrabbing.transform.parent = handAnchor;
    currentlyGrabbing.transform.position = form.transform.position;
    currentlyGrabbing.submittable = currentlyGrabbing.original = currentlyGrabbing.blocked = false;
    currentlyGrabbing.onGrab += Release;
  }

  public void Release () {
    animator.SetTrigger("release");
    currentlyGrabbing.onGrab -= Release;
    currentlyGrabbing = null;
    surf.SetActive(true);
    onFormDelivery?.Invoke(lastFormHanded);
  }

  public void DontTouch (string form) { StopAllCoroutines(); StartCoroutine(_NoToque(form)); }
  IEnumerator _NoToque (string form) {
    yield return StartCoroutine(_Reject(Find(cantTouchIt, form)));
  }

  public void Reject (TinderGuyComment comment) { StartCoroutine(_Reject(comment)); }
  IEnumerator _Reject (TinderGuyComment comment, float lectureTime = 3) {
    guard.SetActive(true);
    if (bubble.messageHolder.text != "") {
      bubble.messageHolder.text = "";
      yield return new WaitForSeconds(0.25f);
    }
    bubble.messageHolder.text = comment.Comment;
    yield return new WaitForSeconds(lectureTime);
    bubble.messageHolder.text = "";
    surf.SetActive(true);
  }

  public TinderGuyComment Find (CommentWithKey[] comments, string key) {
    foreach (CommentWithKey comment in comments) {
      if (comment.key == key) return comment.comment;
    }
    return null;
  }

  public void HandleSubmission (string form) {
    onFormSubmitted?.Invoke(form);
    arm.blockedBySubmission = true;
    animator.SetTrigger("receive submitted form");
  }

  public void ArmTakesForm () {
    arm.blockedBySubmission = false;
    arm.grabbed.transform.parent = transform;
    submittedForm = arm.grabbed.transform;
    arm.grabbed = null;
  }

  public void ArmLeavesForm () {
    submittedForm.transform.parent = submittedAnchor;
    submittedForm.GetComponent<SpriteRenderer>().sortingOrder += SubmissionArea.submittedForms++;
  }
}
