using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Drawing Data", menuName = "Drawing/Data", order = 0)]
public class DrawDataSO : ScriptableObject
{
    public Color Color;
    
    [SerializeField] BrushSO _selectedBrush;
    public event UnityAction OnBrushSet;
    public BrushSO SelectedBrush
    {
        get => _selectedBrush;
        set
        {
            _selectedBrush = value;
            OnBrushSet?.Invoke();
        }
    }

    public float BrushSize = 1f;
    public PaintingSO Painting;

    public int LayerCount { get => Painting.Layers.Length; }

    [SerializeField] int _currentLayer = 0;
    public event UnityAction OnLayerChange;
    public int CurrentLayerIndex 
    {
        get => _currentLayer;
        set
        {
            _currentLayer = value;
            OnLayerChange?.Invoke();
        }
    }
    public Layer CurrentLayer { get => Painting.Layers[CurrentLayerIndex]; }
}
