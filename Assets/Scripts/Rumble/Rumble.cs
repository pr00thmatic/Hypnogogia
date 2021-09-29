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

  [Header("Information")]
  public Animator currentAnimator;
  public static Gamepad gamepad;
  public Coroutine pattern;
  public StethoSign currentSign;

  [Header("Initialization")]
  public PlayerInput input;

  void Reset () { input = GetComponent<PlayerInput>(); }

  void OnEnable () {
    StethoscopeMic.onStatusChange += HandleStatusChange;
    StethoscopeMic.onSignFound += HandleSignFound;
    StethoscopeMic.onSignLost += HandleSignLost;
    StethoOrganUIOverlay.onRumbleDisplayNeeded += HandleDisplayNeed;
  }

  void OnDisable () {
    StethoscopeMic.onStatusChange -= HandleStatusChange;
    StethoscopeMic.onSignFound -= HandleSignFound;
    StethoscopeMic.onSignLost -= HandleSignLost;
    StethoOrganUIOverlay.onRumbleDisplayNeeded -= HandleDisplayNeed;
    if (GetGamepad() != null) GetGamepad().SetMotorSpeeds(0,0);
  }

  void Update () {
    Gamepad found = GetGamepad();
    if (found != null) gamepad = found;
  }

  public Gamepad GetGamepad () {
    return Gamepad.all.FirstOrDefault(g => input.devices.Any(d => d.deviceId == g.deviceId));
  }

  public static void SetRumble (ClinicalSign signCodename) {
    SetRumble(RumblePatterns.actionsHash[signCodename]);
  }

  public static void SetRumble (System.Action<MonoBehaviour> patternTriggerer) {
    Stop();
    patternTriggerer(Instance);
  }

  public static void Stop () {
    Instance.StopAllCoroutines();
  }

  public void HandleStatusChange (StethoscopeMic mic) {
    if (!mic.isGrabbed) { Stop(); return; }
  }

  public void HandleSignFound (StethoSign sign) {
    if (currentSign != sign) {
      currentSign = sign;
      SetRumble(sign.pattern);
    }
  }

  public void HandleSignLost (StethoSign sign) {
    if (currentSign == sign) {
      GetGamepad()?.SetMotorSpeeds(0,0);
      currentSign = null;
      Stop();
    }
  }

  public void HandleDisplayNeed (Animator animator) { currentAnimator = animator; }
}
