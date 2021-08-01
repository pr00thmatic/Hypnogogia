using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TinderGuyComment", menuName = "pr00/Tinder")]
public class TinderGuyComment : ScriptableObject {
  public LocalizedComment[] comments;
  public string Comment {
    get {
      foreach (LocalizedComment c in comments) {
        if (c.location == Localization.selected) return c.comment;
      }
      return comments[0].comment;
    }
  }

}
