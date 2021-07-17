using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class EndingControls : MonoBehaviour {
  [Header("Initialization")]
  public GameObject instructions;

  IEnumerator Start () {
    yield return new WaitForSeconds(5);
    instructions.SetActive(true);
    TheInputInstance.Rafa.Restart.performed += HandleRestart;
  }

  public void HandleRestart (InputAction.CallbackContext ctx) {
    TheInputInstance.Rafa.Restart.performed -= HandleRestart;
    SceneManager.LoadScene(gameObject.scene.name);
  }
}
