using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PaintingSO))]
public class PaintingSOInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Painting"))
        {
            ((PaintingSO)target).GeneratePainting();
        }
    }
}
