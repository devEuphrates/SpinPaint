using Euphrates;
using UnityEngine;
using UnityEngine.Events;

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
        _painting.SetPixels32(Base.GetPixels32());
        Color32[] paintingColors = _painting.GetPixels32();

        for (int i = 0; i < Layers.Length; i++)
        {
            Color32[] layerColors = Layers[i].Painting.GetPixels32();

            for (int j = 0; j < layerColors.Length; j++)
            {
                if (layerColors[j].r < 2)
                    continue;

                paintingColors[j] = Layers[i].Color;
            }
        }

        _painting.SetPixels32(paintingColors);
        _painting.Apply();
    }

    public void GeneratePaintingWithAlphaChannel()
    {
        _paintingWithAlpha = new Texture2D(Base.width, Base.height);
        _paintingWithAlpha.SetPixels32(Base.GetPixels32());
        Color32[] paintingColors = _paintingWithAlpha.GetPixels32();

        for (int i = 0; i < paintingColors.Length; i++)
        {
            if (paintingColors[i].r < 2)
                paintingColors[i] = new Color32(0, 0, 0, 0);
        }

        for (int i = 0; i < Layers.Length; i++)
        {
            Color32[] layerColors = Layers[i].Painting.GetPixels32();

            for (int j = 0; j < layerColors.Length; j++)
            {
                if (layerColors[j].r < 2)
                    continue;

                paintingColors[j] = Layers[i].Color;
            }
        }

        _paintingWithAlpha.SetPixels32(paintingColors);
        _paintingWithAlpha.Apply();
    }
}

[System.Serializable]
public struct Layer
{
    [Header("Textures")]
    [SerializeField] Texture2D _paintedTexture;
    [SerializeField] Texture2D _stencilTexture;
    public Texture2D Painting => _paintedTexture;
    public Texture2D Stencil => _stencilTexture != null ? _stencilTexture : _paintedTexture;
    [Space]
    public Color32 Color;
    public UnityEvent OnSelected;
    public void Selected() => OnSelected?.Invoke();
    public float Data1;
}
