using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartVariant : Variant {
  [Header("Initialization")]
  public GameObject[] variants;
  public Transform spawnPoint;

  public override void Set () {
    Utils.DeleteChildren(spawnPoint);
    Transform spawn = Instantiate(variants[chosen]).transform;
    spawn.parent = spawnPoint;
    spawn.localPosition = Vector3.zero;
    spawn.localScale = Vector3.one;
    spawn.localRotation = Quaternion.identity;
  }
}
