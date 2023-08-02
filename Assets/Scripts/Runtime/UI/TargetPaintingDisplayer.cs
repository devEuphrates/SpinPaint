using UnityEngine;
using UnityEngine.UI;

public class TargetPaintingDisplayer : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] DrawDataSO _drawingData;

    private void OnEnable()
    {
        SetPainting();
        _drawingData.OnPaintingChange += SetPainting;
    }

    private void OnDisable()
    {
        _drawingData.OnPaintingChange -= SetPainting;
    }

    void SetPainting()
    {
        Texture2D texture = _drawingData.Painting.PaintingWithAlpha;
        _image.sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0f, 0f), 1);
    }
}
