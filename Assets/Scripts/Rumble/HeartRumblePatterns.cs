using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HeartRumblePatterns {
  public static float intensity = 0.5f;
  public static float factor = 0.5f;
  public static Dictionary<HeartRumblePattern, System.Func<IEnumerator>> hash =
    new Dictionary<HeartRumblePattern, System.Func<IEnumerator>>() {
      { HeartRumblePattern.Normal, _NormalHeartbeat },
      { HeartRumblePattern.Fast, _FastHeartbeat },
      { HeartRumblePattern.Arrythmic, _Arrythmic }
  };

  public static IEnumerator _Heartbeat (float factor, float wait) {
    float rumbleTime = 0.05f;
    while (true) {
      if (Rumble.gamepad == null) { yield return null; continue; }
      Rumble.gamepad.SetMotorSpeeds(intensity, intensity);
      yield return new WaitForSeconds(rumbleTime);
      Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(wait - rumbleTime);
    }
  }

  public static IEnumerator _NormalHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(60, 100, factor)));
  }

  public static IEnumerator _FastHeartbeat () {
    yield return Rumble.Instance.StartCoroutine(_Heartbeat(factor, 60 / (float) Mathf.Lerp(150, 110, factor)));
  }

  public static IEnumerator _Arrythmic () {
    float rumbleTime = 0.05f;
    while (true) {
      if (Rumble.gamepad == null) { yield return null; continue; }
      Rumble.gamepad.SetMotorSpeeds(intensity, intensity);
      yield return new WaitForSeconds(rumbleTime);
      Rumble.gamepad.SetMotorSpeeds(0,0);
      yield return new WaitForSeconds(60/Random.Range(60, 100f));
    }
  }
}
