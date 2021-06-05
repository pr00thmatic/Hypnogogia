using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Conversations {
[System.Serializable]
public class PieceOfChat {
  public string owner;
  [TextArea]
  public string message;
}
}
