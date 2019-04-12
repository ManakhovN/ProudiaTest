using UnityEngine;

public interface IMovable
{
    Vector3 Position { get; }
    Vector3 SnapPosition(Vector3 position);
    void SnapPosition();
    void Move(Vector3 offset);
}