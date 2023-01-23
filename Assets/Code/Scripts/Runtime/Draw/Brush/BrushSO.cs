using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Brush", menuName = "Drawing/Brush")]
public class BrushSO : ScriptableObject
{
    public Texture2D Texture;
    public Vector2Int[] Coordinates;

    public void GenerateCoordinates()
    {
        List<Vector2Int> coords = new List<Vector2Int>();

        for (int y = 0; y < Texture.height; y++)
        {
            for (int x = 0; x < Texture.width; x++)
            {
                if (Texture.GetPixel(x, y).a < .1f)
                    continue;

                coords.Add(new Vector2Int(x, y));
            }
        }

        Coordinates = coords.ToArray();
    }
}
