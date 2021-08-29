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

  void OnEnable () { StartCoroutine(_OnEnable()); } IEnumerator _OnEnable () {
    yield return new WaitUntil(() => patient.isRandomized);
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
  }
}
