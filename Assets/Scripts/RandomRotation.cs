using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomRotation : MonoBehaviour {
  void Start () {
    transform.Rotate(0,0, Random.Range(0, 360f));
  }
}
