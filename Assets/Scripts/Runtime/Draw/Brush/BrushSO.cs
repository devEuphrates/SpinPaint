using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Brush", menuName = "Drawing/Brush")]
public class BrushSO : ScriptableObject
{
    public Texture2D Texture;
    public Vector2Int[] Coordinates;
#if UNITY_EDITOR
    public void GenerateCoordinates()
    {
        List<Vector2Int> coords = new List<Vector2Int>();

        for (int y = 0; y < Texture.height; y++)
        {
            for (int x = 0; x < Texture.width; x++)
            {
                Color col = Texture.GetPixel(x, y);
                if (col.r < .1f || col.a < .1f)
                    continue;

                coords.Add(new Vector2Int(x, y));
            }
        }

        Coordinates = coords.ToArray();
        EditorUtility.SetDirty(this);
    }
#endif

}
