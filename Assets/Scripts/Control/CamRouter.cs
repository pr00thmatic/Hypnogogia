using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamRouter : MonoBehaviour {
  [Header("Information")]
  public GameObject lastStatus;

  [Header("Initialization")]
  public StateMachine machine;
  public RafaMotion motion;
  public GameObject zoomIn;

  void OnEnable () {
    motion.onDuckStart += HandleDuck;
    motion.onDuckStop += HandleUnduck;
  }

  void OnDisable () {
    motion.onDuckStart -= HandleDuck;
    motion.onDuckStop -= HandleUnduck;
  }

  public void HandleDuck () {
    lastStatus = machine.GetCurrentState().gameObject;
    zoomIn.SetActive(true);
  }

  public void HandleUnduck () {
    if (lastStatus) lastStatus.SetActive(true);
  }
}
