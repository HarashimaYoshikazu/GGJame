using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _Animator;

    private Tween _tweener;

    private void Reset()
    {
        _Animator = GetComponent<Animator>();
    }

    public void Move(float moveTargetY)
    {
        // 移動中なので、何もさせない
        if (_tweener != null)
        {
            return;
        }

        _tweener = transform.DOMoveY(moveTargetY, 1.0f);
        _tweener.onComplete = () => { _tweener = null; };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsCheckForcedScrollGameOver(collision))
        {
            // 強制スクロールでGameOverになる演出があれば

            SendGameOver();
            return;
        }
        else if (IsCheckDropGameOver(collision))
        {
            // ダメなマスでGameOverになる演出があれば

            SendGameOver();
            return;
        }

        // スコアアップ処理
    }

    private bool IsCheckForcedScrollGameOver(Collider2D collision)
    {
        // とりあえず仮置き
        return collision.gameObject.tag == "ScrollWall";
    }

    private bool IsCheckDropGameOver(Collider2D collision)
    {
        // とりあえず仮置き
        return collision.gameObject.tag == "Drop";
    }

    private void SendGameOver()
    {
        // GameManagerにゲームが終了したことを通知
    }

}
