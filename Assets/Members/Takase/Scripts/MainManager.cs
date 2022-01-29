using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : SingletonMonoBehaviour<MainManager>
{
    [SerializeField] private Player _Player;
    [SerializeField] private MapManager _MapManager;
    [SerializeField] private Canvas _StageCanvas;
    [SerializeField] private UIGame _UIGame;

    public Player Player => _Player;

    public MapManager MapManager => _MapManager;

    protected override void OnAwake()
    {
        _MapManager.Init();

        GameManager.Instance.Init();
        _UIGame.UpdateScore(GameManager.Instance.Score);
        _UIGame.Setup();
    }
}
