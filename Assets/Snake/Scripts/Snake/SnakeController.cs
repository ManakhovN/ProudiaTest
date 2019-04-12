using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeController : MonoBehaviour, ISnakeController {
    [SerializeField] private float speed = 10f;
    IBody body;
    IWayProcessor wayProcessor;
    ITracker[] trackers;
    ISpawner spawner;
    ICollisionChecker[] collisionCheckers;
    public IBody Body
    {
        get
        {
            if (body == null)
                body = GetComponent<IBody>();
            return body;
        }
    }

    public IWayProcessor WayProcessor
    {
        get
        {
            if (wayProcessor == null)
                wayProcessor = new SnakeWayProcessor();
            return wayProcessor;
        }
    }

    public ICollisionChecker[] CollisionCheckers
    {
        get
        {
            if (collisionCheckers == null)
                collisionCheckers = GetComponents<ICollisionChecker>();
            return collisionCheckers;
        }
    }

    public void Init(IInput inputController, ISpawner spawner)
    {
        body = GetComponent<IBody>();
        this.spawner = spawner;
        wayProcessor = new SnakeWayProcessor();
        InitTrackers(spawner);
        inputController.OnInputChange += WayProcessor.ProcessInput;
        wayProcessor.OnWayChanged += body.SnapPosition;
        wayProcessor.OnWayChanged += body.Refresh;
    }

    public void InitTrackers(ISpawner spawner) {
        trackers = GetComponentsInChildren<ITracker>();
        foreach (var tracker in trackers)
            tracker.Target = spawner.LastSpawnedObject;
        foreach (var tracker in trackers)
            spawner.OnObjectSpawned += (Transform current) => tracker.Target = current;
    }

    bool paused = true;
    public bool Pause
    {
        get{ return paused;}
        set { this.paused = value; }
    }

    void Update ()
    {

        if (paused)
            return;
        Vector2 move = WayProcessor.GetMovingVector();
        body.Move(move * Time.deltaTime * speed);
        transform.position = body.Position;
        transform.up = move;
        foreach (var tracker in trackers)
            tracker.Refresh();
    }

}
