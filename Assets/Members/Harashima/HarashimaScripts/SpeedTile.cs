using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedTile : TileControllerBase
{

    protected override void TileEffect()
    {
        if (MapManager.I._speed - MapManager.I._decreaseSpeed < MapManager.I._speedDownLimit)
        {
            float diff = MapManager.I._speed - MapManager.I._speedDownLimit;
            MapManager.I._speed = Mathf.Clamp(MapManager.I._speed - MapManager.I._decreaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);

            DOVirtual.DelayedCall(5f, () => {
                MapManager.I._speed = Mathf.Clamp(MapManager.I._speed + diff, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);
            });
        }
        else
        {
            MapManager.I._speed = Mathf.Clamp(MapManager.I._speed - MapManager.I._decreaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);

            DOVirtual.DelayedCall(5f, () => {
                MapManager.I._speed = Mathf.Clamp(MapManager.I._speed + MapManager.I._decreaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);
            });
        }
 

    }

}
