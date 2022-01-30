using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenViewTile : TileControllerBase
{
    protected override void TileEffect()
    {
        //PlayerのフラグをオフにしてUpdateを止める
        MainManager.I.Player.IsGeteItem = true;
        //全てのタイルを見えるようにする
        MainManager.I.MapManager.ChangeVisibleAllTiles(false);
        //もとに戻す
        DOVirtual.DelayedCall(5f, () => {
            MainManager.I.Player.IsGeteItem = false;
        });
    }
}
