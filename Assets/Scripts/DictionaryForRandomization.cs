using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Dictionary", menuName = "pr00/randomized dictionary")]
public class DictionaryForRandomization : ScriptableObject {
  [TextArea]
  public string entries;
  List<string> _entries;
  public List<string> Entries {
    get {
      // if (_entries == null) _entries = new List<string>(entries.Split('\n'));
      _entries = new List<string>(entries.Split('\n'));
      return _entries;
    }
  }
}
