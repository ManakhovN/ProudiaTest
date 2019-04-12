using System;
using UnityEngine;

public interface ISpawner
{
    Transform LastSpawnedObject { get; set; }

    event Action<Transform> OnObjectSpawned;

    void Spawn();
}