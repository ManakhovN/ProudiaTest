using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : Singleton<GameController>, IServiceLocator {
    [SerializeField] SnakeController snakeController;

    private Dictionary<System.Type, object> services = new Dictionary<System.Type, object>();

    public T GetService<T>()
    {
            return (T)services[typeof(T)];
    }

    public void Register<T>(T service)
    {
        services[typeof(T)] = service;
    }
    ISession gameSession;

    protected override void Awake () {
        base.Awake();
        IInput inputController;
        if (Input.touchSupported)
            inputController = gameObject.AddComponent <TouchInput>();
        else
            inputController = gameObject.AddComponent<KeyboardInput>();
        ISpawner spawner = GetComponent<ISpawner>();
        spawner.Spawn();
        snakeController.Init(inputController, spawner);
        Register<IInput>(inputController);
        Register<ISpawner>(spawner);
        Register<ISnakeController>(snakeController);
        gameSession = new GameSession(this);
        Register<ISession>(gameSession);
	}

}
