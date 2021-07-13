using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class ClockHand : MonoBehaviour {
  [Header("Configuration")]
  public bool countsMinutes = false;
  public float joystickSpeed = 360;

  [Header("Information")]
  public float angles;
  public Vector3 lastForward;

  [Header("Initialization")]
  public UsableWithHand usable;

  void OnEnable () { TheInputInstance.Input.Rafa.Grab.canceled += HandleRelease; usable.onUseBegin += HandleBegin; }
  void OnDisable () { TheInputInstance.Input.Rafa.Grab.canceled -= HandleRelease; usable.onUseBegin -= HandleBegin; }

  void Update () {
    if (usable.beingUsed) {
      Vector2 handControl = TheInputInstance.Input.Rafa.MoveHand.ReadValue<Vector2>();
      if (JoystickMouseRouter.IsUsingMouse) {
        Vector3 delta = new Vector3(handControl.x, handControl.y, 0) * Time.deltaTime;
        // don't allow time travel beyond the end of time and before 0 hour
        float going = Vector3.SignedAngle(transform.up, delta, Vector3.forward);
        if (Sky.Instance.hour >= Sky.Instance.endOfTime && going < 0) return;
        if (Sky.Instance.hour <= 0 && going > 0) return;
        transform.up += delta;
      } else {
        // don't allow time travel beyond the end of time and before 0 hour
        float going = Vector3.SignedAngle(transform.up, handControl, Vector3.forward);
        if (Sky.Instance.hour >= Sky.Instance.endOfTime && going < 0) return;
        if (Sky.Instance.hour <= 0 && going > 0) return;
        transform.up = Vector3.RotateTowards(transform.up, new Vector3(handControl.x, handControl.y, 0),
                                             joystickSpeed * Time.deltaTime * Mathf.Deg2Rad, 1);
      }

      angles -= Vector3.SignedAngle(lastForward, transform.up, Vector3.forward);
      lastForward = transform.up;
    }
  }

  void HandleRelease (InputAction.CallbackContext ctx) {
    if (usable.beingUsed) {
      usable.StopUsing();
    }
  }

  public void HandleBegin (UserHand hand) {
    angles = 360 - transform.rotation.eulerAngles.z;
    lastForward = transform.up;
    if (countsMinutes) {
      angles += Mathf.Floor(Sky.Instance.hour) * 360;
    }
  }
}
