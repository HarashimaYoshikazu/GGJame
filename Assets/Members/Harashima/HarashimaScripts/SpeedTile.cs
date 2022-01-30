using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedTile : TileControllerBase
{
    [SerializeField,Tooltip("一時的に下がるスピード")] float _decreaseSpeed = 100f;
    float _currentSpeedDiff;
    protected override void TileEffect()
    {
        MapManager.I._speed =  Mathf.Clamp(MapManager.I._speed - _decreaseSpeed, MapManager.I._speedDownLimit,MapManager.I._speedUpLimit) ;
        DOVirtual.DelayedCall(5f, () => {
            MapManager.I._speed = Mathf.Clamp(MapManager.I._speed + _decreaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit); 
        });   

    }

}
