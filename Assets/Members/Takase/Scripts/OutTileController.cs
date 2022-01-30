using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTileController : TileControllerBase
{
    protected override void TileEffect()
    {
        MainManager.I.Player.PlayerDiedAnime(() =>
        {
            GameManager.Instance.ChangeState(GameState.Result);
        }, true);
    }
}
