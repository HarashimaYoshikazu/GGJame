using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 現在の難易度のState
/// </summary>
public enum Difficulty
{
    Easy,
    Normal,
    Hard
}

/// <summary>
/// マップを生成管理するクラス
/// </summary>
public class MapManager : MonoBehaviour
{
    [Header("生成するマップのプレハブ")]
    [SerializeField, Tooltip("イージー")]
    GameObject _easyMapPrefubs;
    [SerializeField, Tooltip("ノーマル")]
    GameObject _normalMapPrefubs;
    [SerializeField, Tooltip("ハード")]
    GameObject _hardMapPrefubs;

    [Header("生成情報")]
    [SerializeField, Tooltip("何回生成したら難易度を変更するか")]
    int _changeTimes = 3;
    /// <summary>生成のカウント</summary>
    int _instansCount;


    [Header("生成ポジション")]
    [SerializeField, Tooltip("キャンバス")]
    Canvas _canvas;

    /// <summary>シーン上にある全てのタイル</summary>
    List<GameObject> _currentAllTile = new List<GameObject>();
    public List<GameObject> CurrentAllTile { get => _currentAllTile; set => _currentAllTile = value; }

    /// <summary>現在の難易度</summary>
    Difficulty _currentDifficulty;

    private bool _IsInit = false;

    private GameObject _LastMapObj;
    private float _LastMapObjPosX = 0;

    void Start()
    {
        /*
        //最初の難易度はEasyで初期化
        _currentDifficulty = Difficulty.Easy;
        //最初のみ初期位置に生成
        Instantiate(_easyMapPrefubs, _canvas.transform);
        */
    }

    public void Init()
    {
        //最初の難易度はEasyで初期化
        _currentDifficulty = Difficulty.Easy;
        //最初のみ初期位置に生成
        CreateMapPrefab(_easyMapPrefubs);

        _IsInit = true;
    }

    void Update()
    {
        if (!_IsInit)
        {
            return;
        }

        if (_normalMapPrefubs != null)
        {
            InstansMap(_currentDifficulty);
        }
        Debug.Log(_currentDifficulty);
    }

    /// <summary>
    /// 難易度に応じて生成するMapを変更する関数
    /// </summary>
    /// <param name="difficulty">現在の難易度</param>
    void InstansMap(Difficulty difficulty)
    {
        var diff = _LastMapObj.transform.position.x - _LastMapObjPosX;
        if (Mathf.Abs(diff) > 274)
        {
            switch (difficulty)
            {
                //ランダムなマッププレハブを生成,Listに格納
                case Difficulty.Easy:
                    CreateMapPrefab(_easyMapPrefubs);
                    break;

                case Difficulty.Normal:
                    CreateMapPrefab(_normalMapPrefubs);
                    break;

                case Difficulty.Hard:
                    CreateMapPrefab(_hardMapPrefubs);
                    break;
            }

            //生成したらカウントを増やす
            _instansCount++;
            //難易度の判定
            ChangeDifficulty();
        }
    }

    /// <summary>
    /// 時間に応じて難易度を変更する関数
    /// </summary>
    void ChangeDifficulty()
    {
        //生成回数が規定回数を超えたら難易度を上げる

        if (_changeTimes * 2 <= _instansCount && _hardMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Hard;
        }
        else if (_normalMapPrefubs != null && _changeTimes <= _instansCount)
        {
            _currentDifficulty = Difficulty.Normal;
        }
    }

    /// <summary>
    /// タイルのリストを外部から操作するクラス
    /// </summary>
    /// <param name="tile">追加するタイル</param>
    /// <param name="add">追加するならtrue、削除ならfalse</param>
    public void TileControll(GameObject tile, bool add)
    {
        if (add)
        {
            _currentAllTile.Add(tile);
        }
        else
        {
            _currentAllTile.Remove(tile);
        }

    }

    public void ChangeVisibleAllTiles(bool isVisible)
    {
        foreach (var v in CurrentAllTile)
        {
            if (v.TryGetComponent(out TileControllerBase tile))
            {
                tile.SetVisibleCoverdImage(isVisible);
            }
        }
    }

    private void CreateMapPrefab(GameObject obj)
    {
        _LastMapObj = Instantiate(obj, _canvas.transform);
        _LastMapObjPosX = _LastMapObj.transform.position.x;
    }
}

