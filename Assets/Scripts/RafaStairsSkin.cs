using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class RafaStairsSkin : MonoBehaviour {
  [Header("Information")]
  public Transform target;

  [Header("Initialization")]
  public State normalRafa;
  public Transform reachComparisson;
  public StateMachine parent;

  public abstract bool HasReachedTarget ();

  void OnEnable () {
    transform.position = normalRafa.transform.position;
  }

  void Update () {
    if (HasReachedTarget()) {
      normalRafa.transform.position = transform.position;
      normalRafa.gameObject.SetActive(true);
      gameObject.SetActive(false);
    }
  }

  public void Activate () {
    gameObject.SetActive(true);
    parent.gameObject.SetActive(true);
  }
}
