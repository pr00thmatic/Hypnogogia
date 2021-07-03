using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContextualEgg : MonoBehaviour {
  public const int BURNT = 0, COOKED = 1, RAW = 2;
  public static event System.Action onStuck;

  [Header("Configuration")]
  public float totallyCooked = 0.25f;
  public float startBurning = 0.75f;
  public RandomRange timeBetweenOilJump = new RandomRange(0.5f, 1);
  public float zeroWigglesOverride = 0;

  [Header("Information")]
  [Range(0,1)]
  public float wigglyShines = 0;
  public float cooldownToOilJump = 0;
  public float desirableWigglesWithCookingFactor = 0;
  public bool isStuck = false;
  public Pan pan;

  [Header("Initialization")]
  public ContextualCookingReagent reagent;
  public Egg[] eggs;
  public ParticleSystem[] oil;
  public GameObject root;
  public CookedEggInPan cookedEgg;

  void Reset () {
    reagent = GetComponent<ContextualCookingReagent>();
    eggs = GetComponentsInChildren<Egg>();
    oil = GetComponentsInChildren<ParticleSystem>();
  }

  void OnEnable () { reagent.onPutIntoRecipient += HandleRecipient; }
  void OnDisable () { reagent.onPutIntoRecipient -= HandleRecipient; }

  void Update () {
    UpdateSprites();
    UpdateAnimations();
    UpdateStuck();
  }

  public void HandleRecipient () {
    pan = reagent.recipient.GetComponentInParent<Pan>();
    pan.onWash += Wash;
    cookedEgg.transform.parent = pan.eggPlace;
    cookedEgg.transform.localPosition = Vector3.zero;
    cookedEgg.gameObject.SetActive(true);
  }

  public void Wash () {
    if (pan) pan.onWash -= Wash;
    Destroy(cookedEgg.gameObject);
    DestroySelf();
  }

  public void DestroySelf () {
    if (pan) pan.onWash -= Wash;
    Destroy(root);
  }

  public void UpdateSprites () {
    eggs[COOKED].alpha = Mathf.Clamp((reagent.cookingFactor - totallyCooked) / totallyCooked, 0,1);
    eggs[BURNT].alpha = Mathf.Clamp((reagent.cookingFactor - startBurning) / (1 - startBurning), 0,1);

    eggs[BURNT].wigglyShines = eggs[COOKED].wigglyShines = eggs[RAW].wigglyShines =
      Mathf.Min(zeroWigglesOverride, Mathf.Lerp(1, 0, reagent.cookingFactor / startBurning * 0.9f));

    eggs[BURNT].status = eggs[COOKED].status = eggs[RAW].status =
      Mathf.Max((1-zeroWigglesOverride) * 0.5f, Mathf.Lerp(0, 0.5f, (reagent.cookingFactor / startBurning * 1.2f)));
  }

  public void UpdateAnimations () {
    if (reagent && reagent.Hornilla) {
      zeroWigglesOverride = reagent.Hornilla.Value > 0.2f? 1: 0;
    }
    cooldownToOilJump -= Time.deltaTime * zeroWigglesOverride;
    if (cooldownToOilJump <= 0 && reagent.cookingFactor < startBurning) {
      cooldownToOilJump = timeBetweenOilJump.Uniform;
      Utils.RandomPick(oil).Play();
    }
  }

  public void UpdateStuck () {
    if (!isStuck && pan && pan.oil < 0.8f && reagent.cookingFactor > 0.2f) {
      isStuck = true;
      onStuck?.Invoke();
    }
  }
}
