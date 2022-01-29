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

    [SerializeField, Tooltip("生成のインターバル")]
    float _interval;
    /// <summary>生成を判定するタイマー</summary>
    float _timer;


    [Header("生成ポジション")]
    [SerializeField, Tooltip("初期の生成ポジション")]
    Transform _initialTransform;

    [SerializeField, Tooltip("キャンバス")]
    Canvas _canvas;


    /// <summary>現在の難易度</summary>
    Difficulty _currentDifficulty;

    void Start()
    {
        //最初の難易度はEasyで初期化
        _currentDifficulty = Difficulty.Easy;
        //最初のみ初期位置に生成
        Instantiate(_easyMapPrefubs, _canvas.transform);
    }

    void Update()
    {
        if (_normalMapPrefubs != null)
        {
            InstansMap(_currentDifficulty);
        }       
    }

    /// <summary>
    /// 難易度に応じて生成するMapを変更する関数
    /// </summary>
    /// <param name="difficulty">現在の難易度</param>
    void InstansMap(Difficulty difficulty)
    {
        _timer += Time.deltaTime;
        if (_interval< _timer)
        {
            switch (difficulty)
            {
                //ランダムなマッププレハブを生成,Listに格納
                case Difficulty.Easy:
                    Instantiate(_easyMapPrefubs,_canvas.transform);
                    break;

                case Difficulty.Normal:
                    Instantiate(_normalMapPrefubs, _canvas.transform);
                    break;

                case Difficulty.Hard:
                    Instantiate(_hardMapPrefubs, _canvas.transform);
                    break;
            }
            //タイマーを0に
            _timer = 0;
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

        if (_changeTimes*2 <= _instansCount && _hardMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Hard;
        }
        else if(_normalMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Normal;
        }
    }
}
