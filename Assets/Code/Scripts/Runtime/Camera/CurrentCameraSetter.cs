using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CurrentCameraSetter : MonoBehaviour
{
    [SerializeField] CamHolderSO _camHolder;

    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        _camHolder.Cam = camera;
    }
}
