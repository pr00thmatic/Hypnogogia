using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RumblePatterns {
  public static float intensity = 0.5f;
  public static float factor = 0.5f;
  public static Dictionary<ClinicalSign, System.Action<MonoBehaviour>> actionsHash =
    new Dictionary<ClinicalSign, System.Action<MonoBehaviour>>() {
      { ClinicalSign.normalHeart, NormalHeartbeat },
      { ClinicalSign.slowHeart, SlowHeartbeat },
      { ClinicalSign.fastHeart, FastHeartbeat },
      { ClinicalSign.arrythmicHeart, ArrythmicHeart },
      { ClinicalSign.growlingBowels, GrowlingBowels },
      { ClinicalSign.normalBowels, NormalBowels }
  };
  public static Animator animator { get => Rumble.Instance.currentAnimator; }

  public static IEnumerator _Heartbeat (float factor, float wait) {
    float rumbleTime = 0.01f;
    while (true) {
      if (animator) animator.SetTrigger("pulse");
      if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(intensity, intensity);
      yield return new WaitForSeconds(rumbleTime);
      if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(0, 0);
      yield return new WaitForSeconds(wait - rumbleTime);
    }
  }

  public static void NormalHeartbeat (MonoBehaviour caller)
  { caller.StartCoroutine(_NormalHeartbeat()); }
  public static IEnumerator _NormalHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(70, 80, factor)));
  }

  public static void FastHeartbeat (MonoBehaviour caller)
  { caller.StartCoroutine(_FastHeartbeat()); }
  public static IEnumerator _FastHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(120, 130, factor)));
  }

  public static void SlowHeartbeat (MonoBehaviour caller)
  { caller.StartCoroutine(_SlowHeartbeat()); }
  public static IEnumerator _SlowHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(40, 50, factor)));
  }

  public static void ArrythmicHeart (MonoBehaviour caller)
  { caller.StartCoroutine(_ArrythmicHeart()); }
  public static IEnumerator _ArrythmicHeart () {
    float rumbleTime = 0.05f;
    while (true) {
      if (animator) animator.SetTrigger("pulse");
      if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(intensity * 0.5f, intensity * 0.5f);
      yield return new WaitForSeconds(rumbleTime);
      if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(60/Random.Range(60, 100f));
    }
  }

  public static void GrowlingBowels (MonoBehaviour caller)
  { caller.StartCoroutine(_GrowlingBowels()); }
  public static IEnumerator _GrowlingBowels () {
    float elapsed = 0;

    while (true) {
      if (animator) animator.SetFloat("speed", 1);
      float calmTime = Random.Range(3, 4f);
      float pulseTime = 0.02f, silenceTime = 0.05f;
      while (elapsed < calmTime) {
        elapsed += Time.deltaTime;
        if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(intensity * 0.01f, intensity * 0.01f);
        yield return new WaitForSeconds(pulseTime);
        if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(0,0);
        yield return new WaitForSeconds(silenceTime);
        elapsed += pulseTime + silenceTime;
      }

      if (animator) animator.SetFloat("speed", 3);
      float uneasyTime = Random.Range(1, 2f);
      elapsed = 0;
      pulseTime = 0.04f; silenceTime = 0.02f;
      while (elapsed < uneasyTime) {
        elapsed += Time.deltaTime;
        if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(intensity * 0.5f, intensity * 0.5f);
        yield return new WaitForSeconds(pulseTime);
        if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(0,0);
        yield return new WaitForSeconds(silenceTime);
        elapsed += pulseTime + silenceTime;
      }
    }
  }

  public static void NormalBowels (MonoBehaviour caller)
  { caller.StartCoroutine(_NormalBowels()); }
  public static IEnumerator _NormalBowels () {
    if (animator) animator.SetFloat("speed", 1);
    while (true) {
      float pulseTime = 0.02f, silenceTime = 0.05f;
      if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(intensity * 0.01f, intensity * 0.01f);
      yield return new WaitForSeconds(pulseTime);
      if (Rumble.gamepad != null) Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(silenceTime);
    }
  }
}
