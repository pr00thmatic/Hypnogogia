using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class FrontSkin : MonoBehaviour {
  [Header("Initialization")]
  public Patient patient;
  public SpriteResolver face;
  public SpriteResolver[] hair;
  public GameObject female;
  public Animator arms;
  public Animator body;
  public SpriteRenderer[] bodyRenderer;
  public SpriteRenderer[] hairRenderer;
  public SpriteRenderer[] pantsRenderer;
  public SpriteRenderer shoesRenderer;

  void OnEnable () { StartCoroutine(_OnEnable()); } IEnumerator _OnEnable () {
    female.SetActive(!patient.info.male);
    face.SetCategoryAndLabel(face.GetCategory(), patient.info.consciousness.ToString());
    yield return new WaitUntil(() => patient.isRandomized);
    foreach (SpriteResolver resolver in hair) Utils.SetSkinByIndex(resolver, patient.hairStyle.chosen);
    arms.Play(patient.info.pain.ToString());
    body.SetInteger("random", Random.Range(0, 3));
    body.SetTrigger(patient.info.consciousness.ToString());
    foreach (SpriteRenderer body in bodyRenderer) body.color = patient.body.chosen;
    foreach (SpriteRenderer h in hairRenderer) h.color = patient.hair.chosen;
    foreach (SpriteRenderer pants in pantsRenderer) pants.color = patient.pants.chosen;
    shoesRenderer.color = patient.shoes.chosen;
  }
}
