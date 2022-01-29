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
    GameObject[] _easyMapPrefubs;
    [SerializeField, Tooltip("ノーマル")]
    GameObject[] _normalMapPrefubs;
    [SerializeField, Tooltip("ハード")]
    GameObject[] _hardMapPrefubs;

    [Header("生成情報")]
    [SerializeField, Tooltip("何回生成したら難易度を変更するか")]
    int _changeTimes = 3;
    /// <summary>生成のカウント</summary>
    int _instansCount;

    [SerializeField, Tooltip("生成のインターバル")]
    float _interval;
    /// <summary>生成を判定するタイマー</summary>
    float _timer;

    /// <summary>現在のマップが入っているリスト</summary>
    List<GameObject> _currentMaps  = new List<GameObject>() ;

    [Header("生成ポジション")]
    [SerializeField, Tooltip("初期の生成ポジション")]
    Transform _initialTransform;
    [SerializeField,Tooltip("2回目以降の生成ポジション")]
    Transform _instanceTransform;

    /// <summary>一時的に要素数に応じた値を保存しておくランダム変数</summary>
    int _random;
    /// <summary>現在の難易度</summary>
    Difficulty _currentDifficulty;

    void Start()
    {
        //最初の難易度はEasyで初期化
        _currentDifficulty = Difficulty.Easy;
        //最初のみ初期位置に生成
        _random = Random.Range(0,_easyMapPrefubs.Length);
        _currentMaps.Add(Instantiate(_easyMapPrefubs[_random], _initialTransform.position,Quaternion.identity));
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
                    _random = Random.Range(0, _easyMapPrefubs.Length);
                    _currentMaps.Add(Instantiate(_easyMapPrefubs[_random], _instanceTransform.position, Quaternion.identity));
                    break;

                case Difficulty.Normal:
                    _random = Random.Range(0, _normalMapPrefubs.Length);
                    _currentMaps.Add(Instantiate(_normalMapPrefubs[_random], _instanceTransform.position, Quaternion.identity));
                    break;

                case Difficulty.Hard:
                    _random = Random.Range(0, _hardMapPrefubs.Length);
                    _currentMaps.Add(Instantiate(_hardMapPrefubs[_random], _instanceTransform.position, Quaternion.identity));
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
        if (_currentDifficulty == Difficulty.Easy)
        {
            return;
        }
        else if (_changeTimes*2 <= _instansCount && _hardMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Hard;
        }
        else if(_normalMapPrefubs != null)
        {
            _currentDifficulty = Difficulty.Normal;
        }
    }
}
