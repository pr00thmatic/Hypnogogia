using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EggManager : MonoBehaviour {
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

  [Header("Initialization")]
  public Egg[] eggs;
  public ParticleSystem[] oil;
  public ContextualCook cookable;
  public GameObject cookedEggPrototype;

  void Reset () {
    eggs = GetComponentsInChildren<Egg>();
    oil = GetComponentsInChildren<ParticleSystem>();
  }

  void Update () {
    eggs[COOKED].alpha = Mathf.Clamp((cookable.cookingFactor - totallyCooked) / totallyCooked, 0,1);
    eggs[BURNT].alpha = Mathf.Clamp((cookable.cookingFactor - startBurning) / (1 - startBurning), 0,1);

    eggs[BURNT].wigglyShines = eggs[COOKED].wigglyShines = eggs[RAW].wigglyShines =
      Mathf.Min(zeroWigglesOverride, Mathf.Lerp(1, 0, cookable.cookingFactor / startBurning * 0.9f));

    eggs[BURNT].status = eggs[COOKED].status = eggs[RAW].status =
      Mathf.Max((1-zeroWigglesOverride) * 0.5f, Mathf.Lerp(0, 0.5f, (cookable.cookingFactor / startBurning * 1.2f)));

    if (cookable && cookable.stove) {
      zeroWigglesOverride = cookable.stove.originalFire.value > 0.2f? 1: 0;
    }

    cooldownToOilJump -= Time.deltaTime * zeroWigglesOverride;
    if (cooldownToOilJump <= 0 && cookable.cookingFactor < startBurning) {
      cooldownToOilJump = timeBetweenOilJump.Uniform;
      Utils.RandomPick(oil).Play();
    }

    // TODO
    if (!isStuck && GetComponentInParent<ContextualPan>().originalPan.oil < 0.8f && cookable.cookingFactor > 0.2f) {
      isStuck = true;
      onStuck?.Invoke();
    }
  }

  public GameObject Clone () {
    GameObject clone = Instantiate(cookedEggPrototype);
    foreach (Egg egg in eggs) {
      Egg snapshot = Instantiate(egg, Vector3.zero, Quaternion.identity, clone.GetComponent<CookedEggInPan>().pannedEggs);
      snapshot.name = egg.name;
      snapshot.wigglyShines = 0;
      snapshot.status = 0.5f;
      snapshot.transform.localScale = Vector3.one;
    }

    SpriteRenderer[] renderers = clone.GetComponentsInChildren<SpriteRenderer>(true);
    foreach (SpriteRenderer renderer in renderers) {
      renderer.maskInteraction = SpriteMaskInteraction.None;
    }

    clone.GetComponent<CookedEggInPan>().IsStuck =
      GetComponentInParent<ContextualPan>().originalPan.oil < 0.8f && cookable.cookingFactor > 0.2f;
    clone.GetComponent<CookedEggInPan>().status = new EggStatus() { cookingFactor = cookable.cookingFactor };

    return clone;
  }

  public void Mimic (CookedEggInPan cooked) {
    gameObject.SetActive(cooked);
    if (cooked) {
      isStuck = cooked.IsStuck;
      cookable.cookingFactor = cooked.status.cookingFactor;
    } else {
      isStuck = false;
      cookable.cookingFactor = 0;
    }
  }
}
