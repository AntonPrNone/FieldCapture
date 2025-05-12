using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FitObjectToCamera))]
public class FitObjectToCameraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FitObjectToCamera script = (FitObjectToCamera)target;
        if (GUILayout.Button("Fit Object To Camera"))
        {
            script.FitObject();
            EditorUtility.SetDirty(script); // ”бедимс€, что изменени€ сохран€ютс€
        }
    }
}
