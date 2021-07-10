using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecepcionistaMotion : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 5;

  [Header("Initialization")]
  public Animator animator;
  public Transform rootMotion;
  public Transform target;

  void Update () {
    if (rootMotion.position == target.position) {
      animator.SetFloat("speed", 0);
    } else if (Utils.IsInState(animator, "walk") || Utils.IsInState(animator, "standing idle")) {
      if (rootMotion.position.x - target.position.x > 0) {
        rootMotion.rotation = Quaternion.Euler(0, 180, 0);
      } else {
        rootMotion.rotation = Quaternion.Euler(0, 0, 0);
      }
      rootMotion.position = Vector3.MoveTowards(rootMotion.position, target.position, speed * Time.deltaTime);
      animator.SetFloat("speed", 1);
    }
  }
}
