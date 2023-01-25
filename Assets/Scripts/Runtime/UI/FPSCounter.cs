using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FPSCounter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] CanvasGroup _canvasGroup;

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

    int _clickCount = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        _clickCount++;

        if (_clickCount > 9)
            _canvasGroup.alpha = 1f;
    }
}
