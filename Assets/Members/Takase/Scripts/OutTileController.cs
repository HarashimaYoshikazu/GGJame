using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTileController : TileControllerBase
{
    protected override void TileEffect()
    {
        GameManager.Instance.ChangeState(GameState.Result);
    }
}
