using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] Texture2D _painted;
    [SerializeField] Texture2D _empty;
    [SerializeField] Texture2D _stencil;
    Color[] _stencilColors;

    //Texture2D _brushTex;

    //[SerializeField] BrushHolderSO _brushHolder;
    [SerializeField] BrushSO _brush;

    //private void OnEnable()
    //{
    //    _brushHolder.OnBrushSet += SetBrush;
    //}

    //private void OnDisable()
    //{
    //    _brushHolder.OnBrushSet -= SetBrush;
    //}

    private void Start()
    {
        //_brushTex = _brush.Texture;
        _stencilColors = _stencil.GetPixels();

        Color[] emptyPixels = _empty.GetPixels();
        _painted.SetPixels(emptyPixels);
        _painted.Apply(true);
    }


    //void SetBrush() => _brush = _brushHolder.Brush;

    public void Paint(Vector2 uvCoords, Color color)
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

            _painted.SetPixel(coords.x, coords.y, color);

            //area[brushCoords.x + brushCoords.y * _brushTex.width] = color;
        }

        //_painted.SetPixels(offsettedCoords.x, offsettedCoords.y, _brushTex.width, _brushTex.height, area);
        _painted.Apply(true);
    }
}
