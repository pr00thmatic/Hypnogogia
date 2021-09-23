using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(PlayerInput))]
public class Rumble : NonPersistentSingleton<Rumble> {
  [Header("Configuration")]
  public float speed = 1;
  public float waitTime = 0.5f;
  public float pulseTime = 0.01f;
  public int quickConfig = -1;

  [Header("Information")]
  public static Gamepad gamepad;
  public Coroutine pattern;

  [Header("Initialization")]
  public PlayerInput input;

  void Reset () { input = GetComponent<PlayerInput>(); }
  void OnDisable () { if (GetGamepad() != null) GetGamepad().SetMotorSpeeds(0,0); }
  void Update () {
    Gamepad found = GetGamepad();
    if (found != null) gamepad = found;
  }

  public Gamepad GetGamepad () {
    return Gamepad.all.FirstOrDefault(g => input.devices.Any(d => d.deviceId == g.deviceId));
  }

  public static Coroutine SetRumble (RumblePattern pattern) {
    return SetRumble(RumblePatterns.hash[pattern]());
  }

  public static Coroutine SetRumble (IEnumerator pattern) {
    Stop();
    Instance.pattern = Instance.StartCoroutine(pattern);
    return Instance.pattern;
  }

  public static void Stop () {
    Instance.StopAllCoroutines();
    // if (Instance.pattern != null) Instance.StopCoroutine(Instance.pattern);
  }
}
