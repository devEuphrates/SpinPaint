using UnityEngine;

[CreateAssetMenu(fileName = "New Painting", menuName = "Drawing/Painting")]
public class PaintingSO : ScriptableObject
{
    public Texture2D Base;
    public Layer[] Layers;

    Texture2D _painting;
    public Texture2D Painting
    {
        get
        {
            if (!_painting)
                GeneratePainting();

            return _painting;
        }
    }

    Texture2D _paintingWithAlpha;
    public Texture2D PaintingWithAlpha
    {
        get
        {
            if (!_paintingWithAlpha)
                GeneratePaintingWithAlphaChannel();

            return _paintingWithAlpha;
        }
    }

    public void GeneratePainting()
    {
        _painting = new Texture2D(Base.width, Base.height);
        _painting.SetPixels(Base.GetPixels());
        Color[] paintingColors = _painting.GetPixels();

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

        _painting.SetPixels(paintingColors);
        _painting.Apply();
    }

    public void GeneratePaintingWithAlphaChannel()
    {
        _paintingWithAlpha = new Texture2D(Base.width, Base.height);
        _paintingWithAlpha.SetPixels(Base.GetPixels());
        Color[] paintingColors = _paintingWithAlpha.GetPixels();

        for (int i = 0; i < paintingColors.Length; i++)
        {
            if (paintingColors[i].r < .1f)
                paintingColors[i] = new Color(0f, 0f, 0f, 0f);
        }

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

        _paintingWithAlpha.SetPixels(paintingColors);
        _paintingWithAlpha.Apply();
    }
}

[System.Serializable]
public struct Layer
{
    public Texture2D Texture;
    public Color Color;
}
