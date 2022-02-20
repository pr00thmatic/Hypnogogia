using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaUpstairsSkin : RafaStairsSkin {
  public override bool HasReachedTarget () {
    return reachComparisson.position.y >= target.position.y;
  }
}
