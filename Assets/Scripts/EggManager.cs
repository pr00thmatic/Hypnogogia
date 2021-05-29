using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EggManager : MonoBehaviour {
  public const int BURNT = 0, COOKED = 1, RAW = 2;

  [Header("Configuration")]
  public float totallyCooked = 0.25f;
  public float startBurning = 0.75f;
  public RandomRange timeBetweenOilJump = new RandomRange(0.5f, 1);

  [Header("Information")]
  [Range(0,1)]
  public float cookingFactor;
  [Range(0,1)]
  public float wigglyShines = 0;
  public float cooldownToOilJump = 0;

  [Header("Initialization")]
  public Egg[] eggs;
  public ParticleSystem[] oil;

  void Reset () {
    eggs = GetComponentsInChildren<Egg>();
    oil = GetComponentsInChildren<ParticleSystem>();
  }

  void Update () {
    eggs[COOKED].alpha = Mathf.Clamp((cookingFactor - totallyCooked) / totallyCooked, 0,1);
    eggs[BURNT].alpha = Mathf.Clamp((cookingFactor - startBurning) / (1 - startBurning), 0,1);

    eggs[BURNT].wigglyShines = eggs[COOKED].wigglyShines = eggs[RAW].wigglyShines =
      Mathf.Lerp(1, 0, cookingFactor / startBurning * 0.9f);
    eggs[BURNT].status = eggs[COOKED].status = eggs[RAW].status =
      Mathf.Lerp(0, 0.5f, (cookingFactor / startBurning * 1.2f));

    cooldownToOilJump -= Time.deltaTime;
    if (cooldownToOilJump <= 0 && cookingFactor < startBurning) {
      cooldownToOilJump = timeBetweenOilJump.Uniform;
      Utils.RandomPick(oil).Play();
    }
  }
}
