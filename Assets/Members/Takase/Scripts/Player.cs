using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _Animator;

    private Tween _tweener;

    private float _Timer = 1.0f;

    private void Reset()
    {
        _Animator = GetComponent<Animator>();
    }

    private void Update()
    {

        Debug.LogError(transform.position.x);
        if (transform.position.x < -100f)
        {
            GameManager.Instance.ChangeState(GameState.Result);
        }

        if (_tweener != null)
        {
            return;
        }

        _Timer -= Time.deltaTime;
        if (_Timer <= 0)
        {
            MainManager.I.MapManager.ChangeVisibleAllTiles(false);
        }
    }

    public void Move(Transform target, Action onComplete)
    {
        MainManager.I.MapManager.ChangeVisibleAllTiles(true);

        // 移動中なので、何もさせない
        if (_tweener != null)
        {
            return;
        }

        transform.parent = target.transform;
        _tweener = transform.DOLocalMove(Vector3.zero, 0.2f);
        _tweener.onComplete = () =>
        {
            _tweener = null;
            onComplete?.Invoke();
            _Timer = 1.0f;
        };
    }
}
