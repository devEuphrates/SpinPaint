using UnityEngine;
using UnityEngine.Events;

public class BrushHolderSO : MonoBehaviour
{
    Texture2D _texture;
    public Texture2D Brush
    {
        get => _texture;
        set
        {
            _texture = value;
            OnBrushSet?.Invoke();
        }
    }

    public event UnityAction OnBrushSet;
}
