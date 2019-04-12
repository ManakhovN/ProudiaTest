using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWayProcessor: IWayProcessor {
    public event Action OnWayChanged = delegate { };
    private bool AreWaysOpposite(MovingWay newWay, MovingWay currentWay)
    {
        return (Mathf.Abs(newWay - currentWay) == 1);
    }

    private MovingWay DefineMovingWay(Vector3 input)
    {
        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            if (input.x < 0f)
                return MovingWay.Left;
            if (input.x > 0)
                return MovingWay.Right;
        }
        else
        {
            if (input.y > 0f)
                return MovingWay.Up;
            if (input.y < 0f)
                return MovingWay.Down;
        }
        return MovingWay.Up;
    }

    public enum MovingWay
    {
        Right = 0, Left = 1, Up = 4, Down = 5
    }

    MovingWay currentWay = MovingWay.Up;

    public void ProcessInput(Vector3 input)
    {
        var newWay = DefineMovingWay(input);
        if (newWay != currentWay && !AreWaysOpposite(newWay, currentWay))
        {
            OnWayChanged.Invoke();
            currentWay = newWay;
        }
    }

    public Vector2 GetMovingVector()
    {
        switch (currentWay)
        {
            case MovingWay.Down:
                return Vector2.down;
            case MovingWay.Left:
                return Vector2.left;
            case MovingWay.Right:
                return Vector2.right;
            case MovingWay.Up:
                return Vector2.up;
        }
        return Vector2.zero;
    }

    public void Reset()
    {
        currentWay = MovingWay.Up;
    }
}
