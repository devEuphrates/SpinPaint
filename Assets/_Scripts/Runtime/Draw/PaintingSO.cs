using UnityEngine;

public class PaintingSO : ScriptableObject
{
    public int Width;
    public int Height;
    public Layer[] Layers;
    public Texture2D PaintingTexture;

    public void GeneratePainting()
    {
        PaintingTexture = new Texture2D(Width, Height);
        Color[] paintingColors = PaintingTexture.GetPixels();

        for (int i = 0; i < Layers.Length; i++)
        {
            Color[] layerColors = Layers[i].Texture.GetPixels();

            for (int j = 0; j < layerColors.Length; j++)
            {
                if (layerColors[j].r < .1f)
                    continue;

                paintingColors[j] = Layers[i].Color;
            }
        }

        PaintingTexture.SetPixels(paintingColors);
        PaintingTexture.Apply();
    }
}

public struct Layer
{
    public Texture2D Texture;
    public Color Color;
}
