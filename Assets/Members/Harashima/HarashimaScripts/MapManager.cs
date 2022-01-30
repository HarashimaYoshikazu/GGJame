using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 現在の難易度のState
/// </summary>
public enum Difficulty
{
    First,
    Second,
    Third,
    Fourth,
    Fifth
}

/// <summary>
/// マップを生成管理するクラス
/// </summary>
public class MapManager : SingletonMonoBehaviour<MapManager>
{
    [Header("生成するマップのプレハブ")]
    [SerializeField, Tooltip("1st")]
    GameObject _firstPrefub;
    [SerializeField,Tooltip("2nd")]
    GameObject _secondPrefub;
    [SerializeField, Tooltip("3rd")]
    GameObject _thirdPrefub;
    [SerializeField, Tooltip("4th")]
    GameObject _fourthPrefub;
    [SerializeField, Tooltip("5th")]
    GameObject _fifthPrefub;

    [Header("生成情報")]
    [SerializeField, Tooltip("何回生成したら難易度を変更するか")]
    int _changeTimes = 20;
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

    [Header("移動")]
    [SerializeField, Tooltip("マップの移動速度")]
    public float _speed = 100f;
    [SerializeField, Tooltip("スピードの下限")]
    public float _speedDownLimit;
    [SerializeField, Tooltip("スピードの上限")]
    public float _speedUpLimit;
    [SerializeField, Tooltip("一時的に下がるスピード(スピードアイテムで使用)")]
    public　float _decreaseSpeed = 100f;
    [SerializeField, Tooltip("難易度が上がった時に上がるスピード")]
    public float _additionSpeed = 50f;
    [SerializeField, Tooltip("次タイルを表示するしきい値")]
    private float _createMapX = 200f;


    [SerializeField, Tooltip("背景パーティクル1")]
    private GameObject _backParticle1;
    [SerializeField, Tooltip("背景パーティクル2")]
    private GameObject _backParticle2;
    [SerializeField, Tooltip("背景パーティクル3")]
    private GameObject _backParticle3;

    public bool CanStageMove { get; set; } = false;

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
        _currentDifficulty = Difficulty.First;
        //最初のみ初期位置に生成
        CreateMapPrefab(_firstPrefub);

        _IsInit = true;
    }

    void Update()
    {
        Debug.Log(_currentDifficulty);
        if (!_IsInit)
        {
            return;
        }


        InstansMap(_currentDifficulty);

    }

    /// <summary>
    /// 難易度に応じて生成するMapを変更する関数
    /// </summary>
    /// <param name="difficulty">現在の難易度</param>
    void InstansMap(Difficulty difficulty)
    {
        if (!_LastMapObj)
        {
            return;
        }

        var diff = _LastMapObj.transform.position.x - _LastMapObjPosX;
        if (_LastMapObj && Mathf.Abs(diff) > _createMapX)
        {
            switch (difficulty)
            {
                //ランダムなマッププレハブを生成,Listに格納
                case Difficulty.First:
                    CreateMapPrefab(_firstPrefub);
                    if (!_backParticle1.activeSelf)
                    {
                        _backParticle1.SetActive(true);
                    }
                    break;

                case Difficulty.Second:
                    CreateMapPrefab(_secondPrefub);
                    if (!_backParticle2.activeSelf)
                    {
                        _backParticle2.SetActive(true);
                    }
                    break;

                case Difficulty.Third:
                    CreateMapPrefab(_thirdPrefub);
                    if (!_backParticle3.activeSelf)
                    {
                        _backParticle3.SetActive(true);
                    }
                    break;
                case Difficulty.Fourth:
                    CreateMapPrefab(_fourthPrefub);
                    if (!_backParticle3.activeSelf)
                    {
                        _backParticle3.SetActive(true);
                    }
                    break;
                case Difficulty.Fifth:
                    CreateMapPrefab(_fifthPrefub);
                    if (!_backParticle3.activeSelf)
                    {
                        _backParticle3.SetActive(true);
                    }
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

        if (_changeTimes * 4 <= _instansCount && _fifthPrefub != null && _currentDifficulty == Difficulty.Fourth)
        {
            _currentDifficulty = Difficulty.Fifth;
            //スクロールスピードを上げる
            _speed += _additionSpeed;
        }
        else if (_changeTimes * 3 <= _instansCount && _fourthPrefub != null && _currentDifficulty == Difficulty.Third)
        {
            _currentDifficulty = Difficulty.Fourth;
            //スクロールスピードを上げる
            _speed += _additionSpeed;
        }
        else if (_changeTimes * 2 <= _instansCount && _thirdPrefub != null && _currentDifficulty == Difficulty.Second)
        {
            _currentDifficulty = Difficulty.Third;
            //スクロールスピードを上げる
            _speed += _additionSpeed;
        }
        else if (_secondPrefub != null && _changeTimes <= _instansCount+7 && _currentDifficulty == Difficulty.First)
        {
            _currentDifficulty = Difficulty.Second;
            _speed += _additionSpeed;
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

