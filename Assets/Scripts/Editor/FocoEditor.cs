using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Foco))]
public class FocoEditor : Editor {
    Foco Target { get => (Foco) target; }

    public override void OnInspectorGUI () {
        DrawDefaultInspector();
        if (GUILayout.Button("Toggle")) {
          Target.Toggle();
        }
    }

    public static void DrawGizmos (Foco customTarget) {
        using (new Handles.DrawingScope(Handles.color, customTarget.transform.localToWorldMatrix)) {

        }
    }

    void OnSceneGUI () {
        DrawGizmos(Target);
    }
}
