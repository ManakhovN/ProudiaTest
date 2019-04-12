using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisionController : MonoBehaviour, ICollisionChecker {

    public event Action<Transform> OnCollisionEnter;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter(collision.transform);
    }
}
