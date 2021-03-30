using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaMotion : MonoBehaviour {
  [Header("Information")]
  public int orientation = 1;

  [Header("Initialization")]
  public Animator animator;
  public Transform rotationTarget;

  void Update () {
    if (Input.GetAxis("Horizontal") != 0) {
      orientation = (int) Mathf.Sign(Input.GetAxis("Horizontal"));
    } else {
      animator.SetFloat("offset", Random.Range(0, 1f));
    }

    animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    rotationTarget.transform.rotation =
      Quaternion.Euler(Utils.SetY(rotationTarget.transform.rotation.eulerAngles, orientation < 0? 180: 0));
  }
}
