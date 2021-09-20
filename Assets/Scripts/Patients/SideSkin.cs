using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class SideSkin : MonoBehaviour {
  [Header("Initialization")]
  public Patient patient;
  public SpriteResolver face;
  public SpriteResolver body;
  public SpriteResolver hair;
  public SpriteRenderer[] bodyRenderer;
  public SpriteRenderer hairRenderer;
  public SpriteRenderer pantsRenderer;
  public SpriteRenderer shoesRenderer;
  public Animator legsAnimator;
  public Animator armsAnimator;
  public Animator bodyAnimator;

  void OnEnable () { StartCoroutine(_OnEnable()); } IEnumerator _OnEnable () {
    SpriteRenderer[] rs = GetComponentsInChildren<SpriteRenderer>();
    foreach (SpriteRenderer r in rs) r.enabled = false;
    yield return new WaitUntil(() => patient.isRandomized);
    foreach (SpriteRenderer r in rs) r.enabled = true;
    UpdateFromPatient();
  }

  public void UpdateFromPatient () {
    face.SetCategoryAndLabel(face.GetCategory(), patient.info.consciousness.ToString());
    body.SetCategoryAndLabel(body.GetCategory(), patient.info.male? "body": "female body");
    Utils.SetSkinByIndex(hair, patient.hairStyle.chosen);

    foreach (SpriteRenderer b in bodyRenderer) b.color = patient.body.chosen;
    hairRenderer.color = patient.hair.chosen;
    pantsRenderer.color = patient.pants.chosen;
    shoesRenderer.color = patient.shoes.chosen;

    bodyAnimator.Play(patient.info.consciousness.ToString());
    armsAnimator.Play(patient.info.pain.ToString());
  }

  void Update () {
    bodyAnimator.SetFloat("speed", patient.walker.speed);
    legsAnimator.SetFloat("speed", patient.walker.speed);
    armsAnimator.SetFloat("speed", patient.walker.speed);
  }
}
