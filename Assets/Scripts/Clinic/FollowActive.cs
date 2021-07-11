using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class FollowActive : MonoBehaviour {
  public Transform[] targets;
  public Transform rootMotion;

  void Update () {
    foreach (Transform target in targets) {
      if (!target.gameObject.activeInHierarchy) continue;
      rootMotion.position = target.position;
      break;
    }
  }
}
