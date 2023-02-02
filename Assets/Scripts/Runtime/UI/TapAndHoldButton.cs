using Euphrates;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapAndHoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] TriggerChannelSO _tapStart;
    [SerializeField] TriggerChannelSO _tapEnd;

    public void OnPointerDown(PointerEventData eventData) => _tapStart.Invoke();
    
    public void OnPointerUp(PointerEventData eventData) => _tapEnd.Invoke();

    public void OnPointerExit(PointerEventData eventData) => _tapEnd.Invoke();
}
