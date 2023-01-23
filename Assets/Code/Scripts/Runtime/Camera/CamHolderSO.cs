using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Camera Holder", menuName = "Camera/Holder", order = 0)]
public class CamHolderSO : ScriptableObject
{
    Camera _cam;
    public Camera Cam
    {
        get => _cam;
        set
        {
            _cam = value;
            OnCameraSet?.Invoke();
        }
    }

    public event UnityAction OnCameraSet;
}
