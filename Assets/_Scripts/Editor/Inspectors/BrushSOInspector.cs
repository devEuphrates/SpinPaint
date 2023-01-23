using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BrushSO))]
public class BrushSOInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Coordinates"))
        {
            ((BrushSO)target).GenerateCoordinates();
        }
    }
}
