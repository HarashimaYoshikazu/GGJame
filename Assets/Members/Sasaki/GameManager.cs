using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Title,
    InGame,
    Result,
}

public class GameManager
{
    private static GameManager _instance = new GameManager();
    public static GameManager Instance => _instance;
    private GameManager() { }

    public GameState CurrentState { get; set; } = GameState.Title;
    public int Score { get; private set; }

    public void AddScore() => Score++;
    public void ChangeState(GameState state)
    {
        CurrentState = state;

        switch (state)
        {
            case GameState.Result:
                break;
        }
    }

    public void Init()
    {
        Score = 0;
    }
}
