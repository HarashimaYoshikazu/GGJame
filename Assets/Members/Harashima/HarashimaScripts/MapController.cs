using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField, Tooltip("マップの子オブジェクトとして生成されるタイル")]
    GameObject[] _tilePrefub;
    [SerializeField, Tooltip("安全地帯のタイル")]
    GameObject _whiteTile;
    [SerializeField, Tooltip("タイルの生成上限")]
    int _tileLimit;
    [SerializeField, Tooltip("マップの移動速度")]
    float _speed;

    void Start()
    {
        
    }

    void Update()
    {
        if (_tilePrefub != null)
        {
            InstansTile();
        }
        
    }
    void Move()
    {
        
    }

    /// <summary>
    /// 自分の子オブジェクトにタイルを生成する関数
    /// </summary>
    void InstansTile()
    {
            int _whiteIndex = Random.Range(0, _tileLimit);
            for (int i = 0; i < _tileLimit; ++i)
            {
                if (i != _whiteIndex)
                {
                    int random = Random.Range(0, _tileLimit);

                    Instantiate(_tilePrefub[random]);
                }
                else
                {
                    //安全地帯を絶対に生成する
                    Instantiate(_whiteTile);
                }
            }
        
    }
}
