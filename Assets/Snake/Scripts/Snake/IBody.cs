using UnityEngine;

public interface IBody : IRefreshable, IMovable
{
    int PartsCount { get; set; }
    float PartLength { get; set; }
    void Reset();
}