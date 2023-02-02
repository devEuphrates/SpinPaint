using UnityEngine;

public class LinearRaycast : MonoBehaviour, IRayCaster
{
    Transform _transform;

    [SerializeField] float _distance;
    [SerializeField] LayerMask _layerMask;

    readonly RaycastHit EMPTY_HIT = new RaycastHit();
    RaycastHit[] _hits = new RaycastHit[5];

    void Awake() => _transform = transform;

    public bool TryCastRay(Vector3 direction, out RaycastHit hit)
    {
        hit = EMPTY_HIT;
        direction.Normalize();

        Ray ray = new Ray(_transform.position, direction);
        int hitCount = Physics.RaycastNonAlloc(ray, _hits, _distance, _layerMask);


        if (hitCount < 1)
            return false;

        hit = _hits[hitCount - 1];
        return true;
    }
}
