using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (CurrentState == state)
        {
            return;
        }

        CurrentState = state;

        switch (state)
        {
            case GameState.Result:
                // 本当はすぐにタイトルにはいきません
                // TODO: 誰かお願いします
                SceneManager.LoadScene("TitleScene");
                break;
        }
    }

    public void Init()
    {
        Score = 0;
    }
}
