using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaHand : MonoBehaviour {
  [Header("Configuration")]
  public float radius = 1;
  public float angle = 80f;
  public bool invertHand = true;
  public int grabbedSortOffset = -1;

  [Header("Information")]
  public bool follow = false;
  public float timestampFollow = -1;
  public float TimeFollowing { get => Time.time - timestampFollow; }
  public UsableWithHand currentlyUsedItem;
  public Grabbable grabbed;
  public bool Busy { get => grabbed; }
  public bool frameBlockedByInteraction;

  [Header("Initialization")]
  public RafaMetarigTransform metaRig;
  public Transform shoulder;
  public Transform arm1;
  public RafaMotion motion;
  public SphereCollider c;

  void Update () {
    if (Input.GetMouseButtonDown(1)) {
      follow = false;
      metaRig.followCommands = false;
    }

    if (follow && (!currentlyUsedItem || !currentlyUsedItem.takesControl)) {
      float z = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
      Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,z));
      Vector3 d = point - shoulder.position;
      transform.position = Vector3.ClampMagnitude(d, radius) + shoulder.position;
      transform.rotation = arm1.rotation * Quaternion.Euler(0,0,90 * (invertHand? 1: -1));

      if (Input.GetMouseButtonDown(0) && TimeFollowing > 0.05f) {
        Vector3 origin = transform.position + c.center;
        RaycastHit[] hits = Physics.SphereCastAll(origin + Vector3.forward * 5, c.radius, -Vector3.forward, 10);
        print(hits);
        if (hits.Length > 0) {
          bool gotcha = false;
          RaycastHit catched = default(RaycastHit);

          foreach (RaycastHit hit in hits) {
            Grabbable found = hit.collider.GetComponentInParent<Grabbable>();
            if (!found) continue;
            if (!gotcha) {
              catched = hit;
              gotcha = true;
              continue;
            }
            if (Vector3.Distance(hit.point, origin) < Vector3.Distance(catched.point, origin)) {
              catched = hit;
            }
          }

          if (gotcha) {
            catched.collider.GetComponentInParent<Grabbable>().Use(this);
          }
        }
      }
    }
    if (Input.GetMouseButtonUp(0)) {
      frameBlockedByInteraction = false;
    }
  }

  void OnMouseDown () {
    if (!follow) {
      timestampFollow = Time.time;
      follow = true;
      metaRig.followCommands = true;
    }
  }
}
