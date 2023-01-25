using Euphrates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationHandler : MonoBehaviour
{
    [SerializeField] Texture2D _paintedTexture;
    [SerializeField] DrawDataSO _drawingData;

    [Space]
    [Header("Elements")]
    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;

    [Space]
    [SerializeField] string _similarityTextFormat = "%{0}";

    [Space]
    [SerializeField] FloatSO _similarity;

    float _value;

    private void OnEnable()
    {
        _value = CompareHandler.CompareTextures(_drawingData.Painting.Painting, _paintedTexture);

        _similarity.Value = _value;
        Tween.DoTween(0f, _value, 1f, Ease.OutCubic, ShowValues);
    }

    void ShowValues(float value)
    {
        _slider.value = value;
        int val = Mathf.Clamp(Mathf.CeilToInt((int)(value * 100f)), 0, 100);
        _text.text = string.Format(_similarityTextFormat, val.ToString());
    }
}
