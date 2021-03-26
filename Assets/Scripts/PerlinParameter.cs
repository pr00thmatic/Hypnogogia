using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerlinParameter : MonoBehaviour {
  [Header("Configuration")]
  public float speed;
  public string parameter = "speed";

  [Header("Information")]
  public float x;

  [Header("Initialization")]
  public Animator animator;

  void Reset () {
    animator = GetComponent<Animator>();
  }

  void Start () {
    x = transform.GetSiblingIndex() * 1.2f;
    speed += Random.Range(0.2f, -0.2f);
  }

  void Update () {
    animator.SetFloat(parameter, Mathf.PerlinNoise(x, 1));
    x += speed * Time.deltaTime;
  }
}
