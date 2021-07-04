using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using TMPro;

[CustomEditor(typeof(PunchCard))]
public class PunchCardEditor : Editor {
  PunchCard Target { get => (PunchCard) target; }

  public override void OnInspectorGUI () {
    DrawDefaultInspector();
    if (GUILayout.Button("randomize!")) {
      Target.Randomize();
      foreach (Transform child in Target.entriesRoot) {
        TextMeshPro[] labels = child.GetComponentsInChildren<TextMeshPro>();
        foreach (TextMeshPro label in labels) {
          Undo.RecordObject(label, "randomize punch card");
          PrefabUtility.RecordPrefabInstancePropertyModifications(label);
        }
      }
    }
  }

  public static void DrawGizmos (PunchCard customTarget) {
    using (new Handles.DrawingScope(Handles.color, customTarget.transform.localToWorldMatrix)) {

    }
  }

  void OnSceneGUI () {
    DrawGizmos(Target);
  }
}
