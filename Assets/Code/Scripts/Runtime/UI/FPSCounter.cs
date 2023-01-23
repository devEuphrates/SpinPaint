using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    void Awake() => Application.targetFrameRate = 60;

    float _timePassed = 0f;
    float _timeTreshold = 1f;
    void Update()
    {
        _timePassed += Time.deltaTime;

        if (_timePassed < _timeTreshold)
            return;

        _timePassed = 0f;

        _text.text = $"{(int)(1f / Time.unscaledDeltaTime)}FPS";
    }
}
