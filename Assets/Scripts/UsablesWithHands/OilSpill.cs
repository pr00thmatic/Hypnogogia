using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OilSpill : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange rotationRange = new RandomRange(-86, -140);

  [Header("Information")]
  public float z;
  public bool Nope { get => !spiller.enabled; }

  [Header("Initialization")]
  public Spill spiller;

  void Start () {
    rotationRange = new RandomRange((rotationRange.Min + 360) % 360, (rotationRange.Max + 360) % 360);
  }

  void Update () {
    z = transform.rotation.eulerAngles.z;
    if (!rotationRange.IsIn(transform.rotation.eulerAngles.z)) {
      spiller.enabled = false;
      return;
    }
    spiller.enabled = true;

    IOileable oileable = spiller.collided? spiller.collided.GetComponentInParent<IOileable>(): null;

    if (oileable != null) {
      oileable.AddOil(Time.deltaTime);
    }
  }
}
