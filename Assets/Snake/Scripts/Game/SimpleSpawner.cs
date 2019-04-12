using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour, ISpawner
{
    public event Action<Transform> OnObjectSpawned = delegate { };
    [SerializeField] private GameObject prefab;
    [SerializeField] private float border = 4.7f;
    public Transform LastSpawnedObject
    {
        get
        {
            return prefab.transform;
        }

        set
        {
            this.prefab = value.gameObject;
        }
    }

    public void Spawn()
    {
        prefab.transform.position = new Vector2(UnityEngine.Random.Range(-border, border), 
                                                                    UnityEngine.Random.Range(-border, border));
        OnObjectSpawned.Invoke(prefab.transform);
    }
}
