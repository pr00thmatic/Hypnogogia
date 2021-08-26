using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FormSlot : MonoBehaviour {
  public event System.Action<FormSlot> onFill;

  [Header("Configuration")]
  public string expected;
  public string obtained;

  [Header("Information")]
  public bool isFilled = false;
  [SerializeField]
  DictionaryForRandomization _dictionary;
  public virtual DictionaryForRandomization dictionary { get => _dictionary; }

  [Header("Initialization")]
  public ReleasableArea area;
  public Sprite[] possibleHandwritting;
  public SpriteRenderer handwritting;
  public Animator highlight;

  void OnEnable () {
    area.onReleased += HandleRelease;
  }

  void OnDisable () {
    area.onReleased -= HandleRelease;
  }

  void Update () {
    highlight.SetBool("is shinning", !isFilled && area.CanSomeoneBeReleasedInMe);
  }

  public void HandleRelease (ContextuallyGrabbable grabbable) {
    area.onReleased -= HandleRelease;
    area.blocked = true;
    BouncingOption toConsume = grabbable.GetComponent<BouncingOption>();
    obtained = toConsume.label.text;
    handwritting.sprite = Utils.RandomPick(possibleHandwritting);
    toConsume.GetConsumed();
    isFilled = true;
    onFill?.Invoke(this);
  }
}
