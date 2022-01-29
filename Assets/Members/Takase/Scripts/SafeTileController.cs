using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeTileController : TileControllerBase
{
    [SerializeField] private int _AddScore = 1;

    protected override void TileEffect()
    {
        GameManager.Instance.AddScore(_AddScore);
    }
}
