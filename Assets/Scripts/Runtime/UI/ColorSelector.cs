using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] DrawDataSO _drawingData;
    Color _selectedColor;

    public void SetColor(Color color)
    {
        _selectedColor = color;
        _image.color = _selectedColor;
    }

    public void OnSelect()
    {
        _drawingData.Color = _selectedColor;
    }
}
