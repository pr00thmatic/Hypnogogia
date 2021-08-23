using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabbingPointingArm : MonoBehaviour {
  [Header("Information")]
  public ContextuallyGrabbable highlighted;
  public float DistanceToHighlighted {
    get => highlighted? Vector3.Distance(grabAnchor.position, highlighted.transform.position): Mathf.Infinity;
  }

  [Header("Initialization")]
  public Transform grabAnchor;
}
