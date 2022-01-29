using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutTileController : TileControllerBase
{
    protected override void TileEffect()
    {
        Debug.LogError("out");
        GameManager.Instance.ChangeState(GameState.Result);
    }
}
