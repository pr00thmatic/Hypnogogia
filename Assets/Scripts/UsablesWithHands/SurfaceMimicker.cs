using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class SurfaceMimicker : MonoBehaviour {
  [Header("Initialization")]
  public SortingGroup sGroup;

  void Reset () {
    sGroup = GetComponentInParent<SortingGroup>();
  }

  void OnCollisionStay2D (Collision2D c) {
    if (c.collider.GetComponentInParent<HandSelection>()) return;
    if (c.collider.GetComponentInParent<Grabbable>()) {
      transform.parent = c.collider.GetComponentInParent<Grabbable>().transform.parent;
    } else {
      transform.parent = c.collider.transform;
    }
  }
}
