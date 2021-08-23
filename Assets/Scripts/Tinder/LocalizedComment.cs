using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LocalizedComment {
  public string location;
  [TextArea]
  public string comment;

  public static string Get (LocalizedComment[] comments) {
    foreach (LocalizedComment c in comments) {
      if (c.location == Localization.selected) return c.comment;
    }
    return comments[0].comment;
  }

}
