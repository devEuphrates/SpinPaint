using System;
using UnityEngine;

public interface IMovement
{
    public void Move(Vector3 position);
    public event Action OnReached;
}
