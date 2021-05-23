using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OilSpill : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange rotationRange = new RandomRange(-86, -140);

  [Header("Information")]
  public RaycastHit2D[] hit = new RaycastHit2D[1];
  public Vector3 floor;
  public bool nope;
  public float z;

  [Header("Initialization")]
  public LineRenderer spill;
  public Collider2D c;

  void Start () {
    rotationRange = new RandomRange((rotationRange.Min + 360) % 360, (rotationRange.Max + 360) % 360);
  }

  void Update () {
    z = transform.rotation.eulerAngles.z;
    if (!rotationRange.IsIn(transform.rotation.eulerAngles.z)) {
      nope = true;
      spill.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
      return;
    }

    nope = false;
    c.enabled = false;
    IOileable oileable = null;
    if (Physics2D.Raycast(spill.transform.position, -Vector2.up, new ContactFilter2D().NoFilter(), hit) != 0) {
      floor = hit[0].point;
      oileable = hit[0].collider.GetComponentInParent<IOileable>();
    } else {
      floor = spill.transform.position - Vector3.up * 10;
    }
    spill.SetPosition(0, floor);
    spill.SetPosition(1, spill.transform.position);

    if (oileable != null) {
      oileable.AddOil(Time.deltaTime);
    }

    c.enabled = true;
  }
}
