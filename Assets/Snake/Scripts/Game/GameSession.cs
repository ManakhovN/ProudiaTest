using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : ISession {
    public event Action OnGameOver = delegate { };
    public event Action OnGameReset = delegate { };
    public event Action OnGameStart = delegate { };
    public event Action<int> OnScoreChanged = delegate { };
    IServiceLocator gameController;
    ISnakeController snakeController;
    int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set {
            score = value;
            OnScoreChanged(score);
        }
    }

    public GameSession(IServiceLocator gameController) {
        this.gameController = gameController;
        snakeController = gameController.GetService<ISnakeController>();
        InitCollisionCheckers(snakeController);
        gameController.GetService<IInput>().OnInputChange += StartGame;
    }

    public void ResetGame() {
        gameController.GetService<IInput>().OnInputChange += StartGame;
        Score = 0;
        snakeController.Body.Reset();
        snakeController.WayProcessor.Reset();
        OnGameReset();
    }

    private void InitCollisionCheckers(ISnakeController snakeController)
    {
        foreach (var checker in snakeController.CollisionCheckers)
            checker.OnCollisionEnter += CheckCollisions;
    }

    private void CheckCollisions(Transform obj)
    {
        switch (obj.tag)
        {
            case "Target":
                gameController.GetService<ISpawner>().Spawn();
                snakeController.Body.PartsCount++;
                Score++;
                break;
            default:
                GameOver();
                break;
        }
    }

    public void GameOver()
    {
        snakeController.Pause = true;
        OnGameOver();
    }

    public void StartGame(Vector3 vector3 = default(Vector3)) {
        gameController.GetService<IInput>().OnInputChange -= StartGame;
        snakeController.Pause = false;
        OnGameStart();
    }

}
