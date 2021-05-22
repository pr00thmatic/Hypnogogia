using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PerlinParameter : MonoBehaviour {
  [Header("Configuration")]
  public float speed;
  public string parameter = "speed";
  public RandomRange parameterRange = new RandomRange(0, 1);
  public RandomRange speedRandomRange = new RandomRange(0.1f, -0.2f);

  [Header("Information")]
  public float x;

  [Header("Initialization")]
  public Animator animator;

  void Reset () {
    animator = GetComponent<Animator>();
  }

  void Start () {
    x = transform.GetSiblingIndex() * 1.2f;
    speed += speedRandomRange.Uniform;
  }

  void Update () {
    animator.SetFloat(parameter, Mathf.PerlinNoise(x, 1) * parameterRange.Uniform);
    x += speed * Time.deltaTime;
  }
}
