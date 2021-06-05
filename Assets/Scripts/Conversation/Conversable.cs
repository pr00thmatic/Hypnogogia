using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace Conversations {
public class Conversable : MonoBehaviour {
  public event System.Action onDisplayRequested;

  // [Header("Information")]
  public string Key { get => customName == ""? name: customName; }

  [Header("Initialization")]
  public TextMeshPro messageHolder;
  public string customName;

  void OnEnable () {
    Conversables.everyone[Key] = this;
  }

  void OnDisable () {
    Conversables.everyone.Remove(Key);
  }

  public void Display (string message) {
    messageHolder.text = message;
    onDisplayRequested?.Invoke();
  }

  public void Hide () {
    messageHolder.text = "";
  }
}
}
