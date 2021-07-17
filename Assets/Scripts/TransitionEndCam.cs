using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransitionEndCam : MonoBehaviour {
  [Header("Configuration")]
  public float yTarget;

  [Header("Initialization")]
  public GameObject endCamSky;
  public GameObject endCam;

  void OnEnable () {
    transform.position = Utils.SetY(Camera.main.transform.position, yTarget);
    StartCoroutine(_CamPlay());
  }

  IEnumerator _CamPlay () {
    yield return new WaitForSeconds(2);
    endCamSky.SetActive(true);
    yield return new WaitForSeconds(2);
    endCam.SetActive(true);
  }
}
