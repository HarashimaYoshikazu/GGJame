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

    /// <summary>現在、このMapの子オブジェクトになっているタイル</summary>
    List<GameObject> _currentMapTile = new List<GameObject>();
    [Header("タグ")]
    [SerializeField, Tooltip("マップマネージャーのタグ")]
    string _mapManagerTag;
    [SerializeField, Tooltip("マップマネージャーのタグ")]
    string _endZoneTag;

    /// <summary>シーン上に存在するMapManager</summary>
    MapManager _mapManager;

    private void Start()
    {
        _mapManager = GameObject.FindGameObjectWithTag(_mapManagerTag).GetComponent<MapManager>(); 
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
                    //生成したタイルをMapManagerのListに追加する
                    var go = Instantiate(_tilePrefub[random], this.transform);
                    _mapManager.TileControll(go,true) ;
                    //※問題あり、このクラスのListにも追加
                    _currentMapTile.Add(go); 
                }
                else
                {
                //安全地帯を絶対に生成する
                var go = Instantiate(_whiteTile, this.transform);
                _mapManager.TileControll(go,true) ;
                _currentMapTile.Add(go);
                }
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //EndZoneTagに当たったら
        if (collision.gameObject.CompareTag(_endZoneTag))
        {
            foreach (var i in _currentMapTile)
            {
                //MapmnagerのListから削除
                _mapManager.TileControll(i,false);
                //自分も削除
                Destroy(i);
            }
        }
    }
}
