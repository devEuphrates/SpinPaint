using UnityEngine;

public class SpinTest : MonoBehaviour
{
    Transform _transform;

    [SerializeField] float _speed = 20f;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _transform.rotation *= Quaternion.Euler(0f, _speed * Time.fixedDeltaTime, 0f);
    }
}
