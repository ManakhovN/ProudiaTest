using System;
using UnityEngine;

public interface ICollisionChecker
{
    event Action<Transform> OnCollisionEnter;
}