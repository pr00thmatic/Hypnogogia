using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RafaDownstairsSkin : RafaStairsSkin {
  public override bool HasReachedTarget () {
    return reachComparisson.position.y <= target.position.y;
  }
}
