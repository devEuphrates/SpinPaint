using UnityEngine;
using UnityEngine.InputSystem;

public class CursorHandler : MonoBehaviour
{
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        rectTransform.anchoredPosition = mousePosition;
    }
}