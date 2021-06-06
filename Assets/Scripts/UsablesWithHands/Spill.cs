using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spill : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange rotationRange = new RandomRange(-86, -140);

  [Header("Information")]
  public RaycastHit2D[] hit = new RaycastHit2D[1];
  public Vector3 floor;
  public Collider2D collided;

  [Header("Initialization")]
  public LineRenderer spill;
  public Collider2D c;

  void OnDisable () {
    spill.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
    collided = null;
  }

  void Update () {
    if (c) c.enabled = false;

    ContactFilter2D filter = new ContactFilter2D().NoFilter();
    filter.useTriggers = false;

    if (Physics2D.Raycast(spill.transform.position, -Vector2.up, filter, hit) != 0) {
      floor = hit[0].point;
      collided = hit[0].collider;
    } else {
      floor = spill.transform.position - Vector3.up * 10;
      collided = null;
    }
    spill.SetPosition(0, floor);
    spill.SetPosition(1, spill.transform.position);

    if (c) c.enabled = true;
  }
}
