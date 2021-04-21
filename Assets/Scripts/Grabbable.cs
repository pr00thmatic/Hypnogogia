using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UsableWithHand))]
[RequireComponent(typeof(ParentConstraint))]
[RequireComponent(typeof(SortingGroup))]
public class Grabbable : MonoBehaviour {
  [Header("Information")]
  public RafaHand hand;

  [Header("Initialization")]
  public UsableWithHand usable;
  public ParentConstraint mimic;
  public SortingGroup sortGroup;

  void Reset () {
    usable = GetComponent<UsableWithHand>();
    usable.takesControl = false;
    mimic = GetComponent<ParentConstraint>();
    sortGroup = GetComponent<SortingGroup>();
    if (mimic.sourceCount == 0) {
      mimic.AddSource(new ConstraintSource());
    }
  }

  void OnEnable () {
    usable.onUse += HandleUse;
  }

  void OnDisable () {
    usable.onUse -= HandleUse;
  }

  public void HandleUse (RafaHand hand) {
    if (this.hand != hand) {
      transform.parent = null;

      ConstraintSource fuck = mimic.GetSource(0);
      fuck.sourceTransform = hand.transform;
      fuck.weight = 1;
      mimic.SetSource(0, fuck);

      mimic.SetTranslationOffset(0, transform.InverseTransformPoint(hand.transform.position));
      mimic.SetRotationOffset(0, (Quaternion.Inverse(hand.transform.rotation) * transform.rotation).eulerAngles);
      mimic.constraintActive = true;
      sortGroup.sortingLayerName = hand.GetComponent<SortingGroup>().sortingLayerName;
      sortGroup.sortingOrder = hand.GetComponent<SortingGroup>().sortingOrder;
    }
  }
}
