using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphicRepresentationTriggerer : MonoBehaviour {
  void OnTriggerEnter2D (Collider2D c) {
    Debug.Log(Time.time + " " + c, c);
  }
}
