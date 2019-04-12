using System;

public interface ISession {
    int Score { get; set;  }
    event Action<int> OnScoreChanged;
    event Action OnGameOver;
    event Action OnGameReset;
    event Action OnGameStart;

    void ResetGame();
}
