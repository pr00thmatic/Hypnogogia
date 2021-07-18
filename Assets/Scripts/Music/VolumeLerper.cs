using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolumeLerper : MonoBehaviour {
  [Header("Configuration")]
  public float target = 0;
  public float speed = 1;

  //[Header("Information")]
  public float current { get => speaker.volume; set => speaker.volume = value; }

  [Header("Initialization")]
  public AudioSource speaker;

  void Reset () {
    speaker = GetComponent<AudioSource>();
    speaker.volume = target;
  }

  void OnEnable () {
    current = target;
  }

  void Update () {
    current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
  }
}
