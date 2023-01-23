using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] Texture2D _painted;
    [SerializeField] Texture2D _empty;
    Texture2D _stencil;

    [Space]
    [SerializeField] DrawDataSO _drawData;

    private void OnEnable()
    {
        _drawData.OnBrushSet += SetBrush;
        _drawData.OnLayerChange += SetLayer;
    }

    private void OnDisable()
    {
        _drawData.OnBrushSet -= SetBrush;
        _drawData.OnLayerChange -= SetLayer;
    }

    private void Start()
    {
        SetLayer();
        SetBrush();

        Color[] emptyPixels = _empty.GetPixels();
        _painted.SetPixels(emptyPixels);
        _painted.Apply(true);
    }

    BrushSO _brush;
    void SetBrush() => _brush = _drawData.SelectedBrush;

    Color[] _stencilColors;
    void SetLayer()
    {
        _stencil = _drawData.CurrentLayer.Texture;
        _stencilColors = _stencil.GetPixels();
    }

    public void Paint(Vector2 uvCoords)
    {
        Vector2Int pixelCoords = new Vector2Int((int)(uvCoords.x * _painted.width), (int)(uvCoords.y * _painted.height));
        Vector2Int brushHalfSize = new Vector2Int((int)(_brush.Texture.width * .5f), (int)(_brush.Texture.height * .5f));
        Vector2Int offsettedCoords = new Vector2Int(pixelCoords.x - brushHalfSize.x, pixelCoords.y - brushHalfSize.y);

        //Color[] area = _painted.GetPixels(offsettedCoords.x, offsettedCoords.y, _brush.Texture.width, _brush.Texture.height);

        for (int i = 0; i < _brush.Coordinates.Length; i++)
        {
            Vector2Int brushCoords = _brush.Coordinates[i];
            Vector2Int coords = new Vector2Int(offsettedCoords.x + brushCoords.x, offsettedCoords.y + brushCoords.y);

            int indx = coords.x + coords.y * _stencil.width;

            if (indx > _stencilColors.Length - 1 || indx < 0)
                continue;

            Color col = _stencilColors[indx];
            if (col.r < .1f)
                continue;

            _painted.SetPixel(coords.x, coords.y, _drawData.Color);

            //area[brushCoords.x + brushCoords.y * _brushTex.width] = color;
        }

        //_painted.SetPixels(offsettedCoords.x, offsettedCoords.y, _brushTex.width, _brushTex.height, area);
        _painted.Apply(true);
    }
}
