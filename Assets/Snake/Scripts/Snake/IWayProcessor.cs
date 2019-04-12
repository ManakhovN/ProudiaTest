using System;
using UnityEngine;

public interface IWayProcessor
{
    event Action OnWayChanged;
    void ProcessInput(Vector3 obj);
    Vector2 GetMovingVector();
    void Reset();
}