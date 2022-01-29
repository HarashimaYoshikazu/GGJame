using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTileController : TileControllerBase
{
    protected override void TileEffect()
    {
        Debug.LogError("safe");
        GameManager.Instance.AddScore();
    }
}
