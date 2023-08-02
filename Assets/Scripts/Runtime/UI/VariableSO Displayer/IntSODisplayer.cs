using Euphrates;
using TMPro;
using UnityEngine;

public class IntSODisplayer : MonoBehaviour
{
    [SerializeReference] IntSO _value;
    [SerializeReference] TextMeshProUGUI _text;

    [Space]
    [SerializeField] string _format = "{0}";

    private void OnEnable()
    {
        _value.OnChange += OnValueChange;
        OnValueChange(0);
    }

    private void OnDisable()
    {
        _value.OnChange -= OnValueChange;
    }

    void OnValueChange(int change)
    {
        string text = string.IsNullOrWhiteSpace(_format) ? _value.Value.ToString() 
            : string.Format(_format, _value.Value);

        _text.text = text;
    }
}
