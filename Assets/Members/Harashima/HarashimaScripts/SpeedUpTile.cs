using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpeedUpTile : TileControllerBase
{

    protected override void TileEffect()
    {
        if (MapManager.I._speed + MapManager.I._increaseSpeed > MapManager.I._speedUpLimit)
        {
            float diff = MapManager.I._speed + MapManager.I._speedUpLimit;
            MapManager.I._speed = Mathf.Clamp(MapManager.I._speed + MapManager.I._increaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);

            DOVirtual.DelayedCall(5f, () => {
                MapManager.I._speed = Mathf.Clamp(MapManager.I._speed - diff, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);
            });
        }
        else
        {
            MapManager.I._speed = Mathf.Clamp(MapManager.I._speed + MapManager.I._increaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);

            DOVirtual.DelayedCall(5f, () => {
                MapManager.I._speed = Mathf.Clamp(MapManager.I._speed - MapManager.I._increaseSpeed, MapManager.I._speedDownLimit, MapManager.I._speedUpLimit);
            });
        }


    }

}
