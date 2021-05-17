using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class Surface : MonoBehaviour {
  [Header("Initialization")]
  public SortingGroup sGroup;
  public int offset;

  public void PoseOnTop (SortingGroup thing) {
    Utils.Set(thing, sGroup.sortingLayerName, sGroup.sortingOrder + offset);
  }

}
