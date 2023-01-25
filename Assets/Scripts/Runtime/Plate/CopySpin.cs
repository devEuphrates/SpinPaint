using UnityEngine;

public class CopySpin : MonoBehaviour
{
    Transform _transform;
    [SerializeField] Transform _copied;

    private void Awake()
    {
        if (!_copied)
            Destroy(this);

        _transform = transform;
    }

    private void FixedUpdate() => _transform.rotation = _copied.rotation;
}
