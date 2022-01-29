using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("移動")]
    [SerializeField, Tooltip("マップの移動速度")]
    float _speed;
    [Header("タイル関係（生成する場合のみ設定が必要）")]
    [SerializeField, Tooltip("マップの子オブジェクトとして生成されるタイル")]
    GameObject[] _tilePrefub;
    [SerializeField, Tooltip("安全地帯のタイル")]
    GameObject _whiteTile;
    [SerializeField, Tooltip("タイルの生成上限")]
    int _tileLimit;
    List<GameObject> _currentTile = new List<GameObject>();

    private void Start()
    {
        if (_tilePrefub != null)
        {
            InstansTile();
        }
    }
    void Update()
    {
        Move();       
    }
    void Move()
    {
        this.transform.Translate(-(_speed)*Time.deltaTime, 0,0);
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
                    int random = Random.Range(0, _tilePrefub.Length);

                    _currentTile.Add(Instantiate(_tilePrefub[random], this.transform)) ;
                }
                else
                {
                    //安全地帯を絶対に生成する
                    _currentTile.Add(Instantiate(_whiteTile, this.transform)) ;
                }
            }
        
    }
}
