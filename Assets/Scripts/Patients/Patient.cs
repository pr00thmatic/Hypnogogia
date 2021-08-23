using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Collections;
using System.Collections.Generic;

public class Patient : MonoBehaviour {
  [Header("Initialization")]
  public SpriteResolver face;
  public SpriteResolver[] hair;
  public GameObject female;
  public Animator arms;
  public ClinicalInfo info;
  public Animator body;
  public GameObject interactIndicator;

  void OnEnable () {
    female.SetActive(!info.male);
    face.SetCategoryAndLabel(face.GetCategory(), info.consciousness.ToString());
    Utils.RandomSkin(hair);
    arms.Play(info.pain.ToString());
    body.SetInteger("random", Random.Range(0, 3));
    body.SetTrigger(info.consciousness.ToString());
  }
}
