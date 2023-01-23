using UnityEngine;

[CreateAssetMenu(fileName = "New Painting", menuName = "Drawing/Painting")]
public class PaintingSO : ScriptableObject
{
    public Texture2D Base;
    public Layer[] Layers;
    public Texture2D PaintingTexture;

    public void GeneratePainting()
    {
        PaintingTexture = new Texture2D(Base.width, Base.height);
        PaintingTexture.SetPixels(Base.GetPixels());
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

[System.Serializable]
public struct Layer
{
    public Texture2D Texture;
    public Color Color;
}
