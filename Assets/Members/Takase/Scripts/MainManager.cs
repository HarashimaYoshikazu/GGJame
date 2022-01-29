using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : SingletonMonoBehaviour<MainManager>
{
    [SerializeField] private Player _Player;
    [SerializeField] private MapManager _MapManager;
    [SerializeField] private Canvas _StageCanvas;

    public Player Player => _Player;

    protected override void OnAwake()
    {

    }
}
