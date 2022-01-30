﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : SingletonMonoBehaviour<MainManager>
{
    [SerializeField] private Player _Player;
    [SerializeField] private MapManager _MapManager;
    [SerializeField] private Canvas _StageCanvas;
    [SerializeField] private UIGame _UIGame;

    [SerializeField] private GameObject _resultGameObject;

    public Player Player => _Player;

    public MapManager MapManager => _MapManager;

    protected override void OnAwake()
    {
        _MapManager.Init();

        GameManager.Instance.Init();
        _UIGame.UpdateScore(GameManager.Instance.Score);
        _UIGame.Setup();
    }

    private void Update()
    {
        // リザルトステート状態になったら、リザルト画面アクティブ切替
        if (GameManager.Instance.CurrentState == GameState.Result && !_resultGameObject.activeSelf)
        {
            _resultGameObject.SetActive(true);
        }
    }
}
