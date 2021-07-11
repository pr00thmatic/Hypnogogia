using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargetedMotion : MonoBehaviour {
  public event System.Action onArrive;

  [Header("Configuration")]
  public float speed = 5;
  public string[] allowedWalkStates = new string[] { "walk", "standing idle" };
  public bool flip = false;

  [Header("Information")]
  public float currentSpeed = 0;
  public bool arrived = false;

  [Header("Initialization")]
  public Animator animator;
  public Transform rootMotion;
  public Transform target;

  void Update () {
    if (rootMotion.position == target.position) {
      animator.SetFloat("speed", 0);
      if (!arrived) {
        arrived = true;
        onArrive?.Invoke();
      }
    } else {
      arrived = false;
      bool canWalk = allowedWalkStates.Length == 0;
      foreach (string state in allowedWalkStates) {
        if (Utils.IsInState(animator, state)) {
          canWalk = true;
          break;
        }
      }
      if (canWalk) {
        if ((rootMotion.position.x - target.position.x) * (flip? -1: 1) > 0) {
          rootMotion.rotation = Quaternion.Euler(0, 180, 0);
        } else {
          rootMotion.rotation = Quaternion.Euler(0, 0, 0);
        }
        rootMotion.position = Vector3.MoveTowards(rootMotion.position, target.position, speed * Time.deltaTime);
        animator.SetFloat("speed", 1);
      }
    }

    currentSpeed = animator.GetFloat("speed");
  }
}
