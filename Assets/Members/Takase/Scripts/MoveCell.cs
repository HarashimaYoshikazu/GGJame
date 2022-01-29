using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MoveCell : MonoBehaviour
{
    [SerializeField] private Player _Player;

    [SerializeField] private float _moveTargetY;
    public float MoveTargetY => _moveTargetY;

    public void OnClick()
    {
    }
}
