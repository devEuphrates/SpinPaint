using UnityEngine;

public interface IRayCaster
{
    public bool TryCastRay(Vector3 direction, out RaycastHit hit);
}
