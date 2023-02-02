using UnityEngine;

[CreateAssetMenu(fileName = "New Brush", menuName = "Drawing/Brush")]
public class BrushSO : ScriptableObject
{
    [SerializeField] Texture2D _texture;

    Texture2D _brush;
    public Texture2D Brush
    {
        get
        {
            if (!_brush)
            {
                CreateTexture();
                ResizeBrush();
            }

            return _brush;
        }
    }

    [SerializeField] float _brushSize = 1f;
    public float BrushSize
    {
        get => _brushSize;
        set
        {
            if (_brushSize == value)
                return;

            _brushSize = value;
            ResizeBrush();
        }
    }

    void CreateTexture()
    {
        _brush = new Texture2D(_texture.width, _texture.height, _texture.format, true);
        _brush.SetPixels32(_texture.GetPixels32());
    }

    void ResizeBrush()
    {
        int w = (int)(_texture.width * _brushSize);
        int h = (int)(_texture.height * _brushSize);

        _brush = Resize(_texture, w, h);
    }

    Texture2D Resize(Texture2D texture2D, int targetX, int targetY)
    {
        RenderTexture rt = new RenderTexture(targetX, targetY, 24);
        RenderTexture.active = rt;
        Graphics.Blit(texture2D, rt);
        Texture2D result = new Texture2D(targetX, targetY);
        result.ReadPixels(new Rect(0, 0, targetX, targetY), 0, 0);
        result.Apply();
        return result;
    }

    public void SetSize(float size) => BrushSize = size;

    //    public Vector2Int[] Coordinates;
    //#if UNITY_EDITOR
    //    public void GenerateCoordinates()
    //    {
    //        List<Vector2Int> coords = new List<Vector2Int>();

    //        for (int y = 0; y < Texture.height; y++)
    //        {
    //            for (int x = 0; x < Texture.width; x++)
    //            {
    //                Color col = Texture.GetPixel(x, y);
    //                if (col.r < .1f || col.a < .1f)
    //                    continue;

    //                coords.Add(new Vector2Int(x, y));
    //            }
    //        }

    //        Coordinates = coords.ToArray();
    //        EditorUtility.SetDirty(this);
    //    }
    //#endif

}
