using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Restarter : MonoBehaviour {
  void Update () {
    if (Keyboard.current.escapeKey.wasPressedThisFrame) {
      SceneManager.LoadScene(gameObject.scene.name);
    }
  }
}
