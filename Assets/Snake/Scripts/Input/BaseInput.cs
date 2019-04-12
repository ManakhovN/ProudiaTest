using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInput : MonoBehaviour, IInput
{
    public event Action<Vector3> OnInputChange = delegate { };
    private Vector2 inputAxis;

    public Vector2 InputAxis
    {
        get { return inputAxis; }
        set
        {
            inputAxis = value;
            if (inputAxis.x != 0f || inputAxis.y != 0f)
                OnInputChange.Invoke(inputAxis);
        }
    }

    public virtual void Start()
    {
        var session = GameController.Instance.GetService<ISession>();
        session.OnGameReset += Reset;
    }

    public virtual void Reset() {
        InputAxis = Vector2.zero;
    }

    public virtual void Update() {

    }
}
