using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour, IBody, ICollisionChecker {
    [SerializeField] private LineRenderer trail;
    [SerializeField] private float partLength = 1f;
    [SerializeField] private int startPartsCount = 10;
    private int partsCount = 10;
    private Vector3[] bodyParts;

    public event Action<Transform> OnCollisionEnter = delegate { };

    public Vector3 Position
    {
        get
        {
            return bodyParts[0];
        }
    }

    public int PartsCount
    {
        get
        {
            return partsCount;
        }

        set
        {
            int oldPartsCount = partsCount;
            partsCount = value;
            var newBodyParts = new Vector3[partsCount];
            int j = 0;
            if (bodyParts != null)
            {
                for (int i = 0; i < newBodyParts.Length; i++)
                {
                    newBodyParts[i] = bodyParts[j];
                    if (j < oldPartsCount - 1)
                        j++;
                }
            }
            bodyParts = newBodyParts;
        }
    }

    public float PartLength
    {
        get
        {
            return partLength;
        }

        set
        {
            partLength = value;
        }
    }

    Collider2D circleCollider;

    public void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        Reset();
    }

    public void Reset()
    {
        PartsCount = startPartsCount;
        bodyParts[0] = Vector3.zero;
        transform.position = bodyParts[0];
        transform.up = Vector2.up;
        for (int i = 1; i < PartsCount; i++)
        {
            bodyParts[i] = bodyParts[0] + Vector3.down * i * partLength;
        }
        trail.positionCount = PartsCount;
        trail.SetPositions(bodyParts);
    }

    public Vector3 SnapPosition(Vector3 position)
    {
        Vector3 result = position;
        float coloumn = result.x / PartLength;
        float row = result.y / PartLength;
        result.x = Mathf.RoundToInt(coloumn) * PartLength;
        result.y = Mathf.RoundToInt(row) * PartLength;
        return result;
    }

    public void SnapPosition()
    {
        bodyParts[0] = SnapPosition(bodyParts[0]);
    }

    public void Move(Vector3 move)
    {
        float moveMagnitude = move.magnitude;
        if ((bodyParts[0] - bodyParts[1]).magnitude > PartLength * 0.99f)
            Refresh();

        var lastPartDelta = (bodyParts[PartsCount - 1] - bodyParts[PartsCount - 2]);
        if (lastPartDelta.magnitude > move.magnitude)
            bodyParts[PartsCount - 1] = Vector3.MoveTowards(bodyParts[PartsCount - 1], bodyParts[PartsCount - 2], moveMagnitude);
       
        bodyParts[0] += (Vector3)move;
        trail.positionCount = PartsCount;
        trail.SetPositions(bodyParts);
        CheckCollisions();
    }

    public void CheckCollisions() {
        for (int i = 3; i < bodyParts.Length; i++)
        {
            if (circleCollider.OverlapPoint(bodyParts[i]))
            {
                OnCollisionEnter(transform);
                return;
            }
        }
    }

    public void Refresh()
    {
        for (int i = PartsCount - 2; i > 0; i--)
        {
            bodyParts[i] = bodyParts[i - 1];
        }
    }

}
