using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTile : TileControllerBase
{
    [SerializeField,Tooltip("一時的に下がるスピード")] float _decreaseSpeed = 100f;
    protected override void TileEffect()
    {
        if (MapManager.I._speed<MapManager.I._speedDownLimit)
        {
            MapManager.I._speed = MapManager.I._speedDownLimit;
        }
        else
        {
            MapManager.I._speed -= _decreaseSpeed;
        }
        
    }

}
