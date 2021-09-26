using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedTools {
  public static Dictionary<ClinicalSign, StethoBodyPart> signToBody = new Dictionary<ClinicalSign, StethoBodyPart>() {
    { ClinicalSign.normalHeart, StethoBodyPart.heart },
    { ClinicalSign.fastHeart, StethoBodyPart.heart },
    { ClinicalSign.slowHeart, StethoBodyPart.heart },
    { ClinicalSign.arrythmicHeart, StethoBodyPart.heart },
    { ClinicalSign.normalBowels, StethoBodyPart.guts },
    { ClinicalSign.growlingBowels, StethoBodyPart.guts },
  };
}
