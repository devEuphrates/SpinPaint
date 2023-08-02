using Euphrates;
using TMPro;
using UnityEngine;

public class FloatSODisplayer : MonoBehaviour
{
    [SerializeReference] FloatSO _value;
    [SerializeReference] TextMeshProUGUI _text;

    [Space]
    [SerializeField] string _format = "{0}";
    [SerializeField] string _toStringParams = "";

    private void OnEnable()
    {
        _value.OnChange += OnValueChange;
        OnValueChange(0);
    }

    private void OnDisable()
    {
        _value.OnChange -= OnValueChange;
    }

    void OnValueChange(float change)
    {
        string text = string.IsNullOrWhiteSpace(_format) ? _value.Value.ToString(_toStringParams)
            : string.Format(_format, _value.Value.ToString(_toStringParams));

        _text.text = text;
    }
}
