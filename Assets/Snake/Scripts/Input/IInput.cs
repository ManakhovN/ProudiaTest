using System;
using UnityEngine;

public interface IInput
{
    event Action<Vector3> OnInputChange;
    Vector2 InputAxis { get; set; }
}