using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(TinderGuy))]
public class TinderGuyEditor : Editor {
  TinderGuy Target { get => (TinderGuy) target; }

  public override void OnInspectorGUI () {
    DrawDefaultInspector();
    if (GUILayout.Button("Randomize")) {
      Target.Randomize();
    }
  }
}
