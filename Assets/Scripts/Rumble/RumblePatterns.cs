using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RumblePatterns {
  public static float intensity = 0.5f;
  public static float factor = 0.5f;
  public static Dictionary<RumblePattern, System.Func<IEnumerator>> hash =
    new Dictionary<RumblePattern, System.Func<IEnumerator>>() {
      { RumblePattern.normalHeart, _NormalHeartbeat },
      { RumblePattern.slowHeart, _SlowHeartbeat },
      { RumblePattern.fastHeart, _FastHeartbeat },
      { RumblePattern.arrythmicHeart, _ArrythmicHeart },
      { RumblePattern.growlingBowels, _GrowlingBowels },
      { RumblePattern.normalBowels, _NormalBowels }
  };

  public static IEnumerator _Heartbeat (float factor, float wait) {
    float rumbleTime = 0.01f;
    while (true) {
      if (Rumble.gamepad == null) { yield return null; continue; }
      Rumble.gamepad.SetMotorSpeeds(intensity, intensity);
      yield return new WaitForSeconds(rumbleTime);
      Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(wait - rumbleTime);
    }
  }

  public static IEnumerator _NormalHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(70, 80, factor)));
  }

  public static IEnumerator _FastHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(120, 130, factor)));
  }

  public static IEnumerator _SlowHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(40, 50, factor)));
  }

  public static IEnumerator _ArrythmicHeart () {
    float rumbleTime = 0.05f;
    while (true) {
      if (Rumble.gamepad == null) { yield return null; continue; }
      Rumble.gamepad.SetMotorSpeeds(intensity * 0.5f, intensity * 0.5f);
      yield return new WaitForSeconds(rumbleTime);
      Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(60/Random.Range(60, 100f));
    }
  }

  public static IEnumerator _GrowlingBowels () {
    float elapsed = 0;

    while (true) {
      float calmTime = Random.Range(3, 4f);
      float pulseTime = 0.02f, silenceTime = 0.05f;
      while (elapsed < calmTime) {
        elapsed += Time.deltaTime;
        if (Rumble.gamepad == null) { yield return null; continue; }
        Rumble.gamepad.SetMotorSpeeds(intensity * 0.01f, intensity * 0.01f);
        yield return new WaitForSeconds(pulseTime);
        Rumble.gamepad.SetMotorSpeeds(0,0);
        yield return new WaitForSeconds(silenceTime);
        elapsed += pulseTime + silenceTime;
      }

      float uneasyTime = Random.Range(1, 2f);
      elapsed = 0;
      pulseTime = 0.04f; silenceTime = 0.02f;
      Debug.Log("uneasy! " + Time.time);
      while (elapsed < uneasyTime) {
        elapsed += Time.deltaTime;
        Rumble.gamepad.SetMotorSpeeds(intensity * 0.5f, intensity * 0.5f);
        yield return new WaitForSeconds(pulseTime);
        Rumble.gamepad.SetMotorSpeeds(0,0);
        yield return new WaitForSeconds(silenceTime);
        elapsed += pulseTime + silenceTime;
      }
      Debug.Log("ok again " + Time.time);
    }
  }

  public static IEnumerator _NormalBowels () {
    while (true) {
      float pulseTime = 0.02f, silenceTime = 0.05f;
      if (Rumble.gamepad == null) { yield return null; continue; }
      Rumble.gamepad.SetMotorSpeeds(intensity * 0.01f, intensity * 0.01f);
      yield return new WaitForSeconds(pulseTime);
      Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(silenceTime);
    }
  }
}
