using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LocalizedComment {
  public string location;
  [TextArea]
  public string comment;
}
