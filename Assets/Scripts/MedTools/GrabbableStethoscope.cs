using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;

public class GrabbableStethoscope : MonoBehaviour {
  [Header("Information")]
  public Rafa rafa;
  public Vector3 micOriginalPos;

  [Header("Initialization")]
  public Transform anchor;
  public Transform mic;
  public Grabbable grabbable;
  public SortingGroup sGroup;

  void Awake () {
    micOriginalPos = mic.localPosition;
  }

  void OnEnable () {
    grabbable.onGrabbed += HandleGrab;
    grabbable.onDropped += HandleDrop;
  }

  void OnDisable () {
    grabbable.onGrabbed -= HandleGrab;
    grabbable.onDropped -= HandleDrop;
  }

  void Update () {
    if (grabbable.hand) {
      transform.position = rafa.head.TransformPoint(anchor.localPosition);
      mic.transform.position = grabbable.hand.movingHand.position;
    }
  }

  public void HandleGrab (GrabbingHand hand) {
    sGroup.enabled = false;
    rafa = hand.GetComponentInParent<Rafa>();
    transform.parent = rafa.standingRafa;
    transform.localScale =
      Utils.SetX(transform.localScale, Mathf.Abs(transform.localScale.x) * rafa.motion.orientation);
  }

  public void HandleDrop () {
    sGroup.enabled = false;
    transform.position = mic.transform.position;
    mic.localPosition = micOriginalPos;
  }
}
