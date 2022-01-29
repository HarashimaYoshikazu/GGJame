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

    private void Reset()
    {
        _Animator = GetComponent<Animator>();
    }

    public void Move(Transform target, Action onComplete)
    {
        // 移動中なので、何もさせない
        if (_tweener != null)
        {
            return;
        }

        transform.parent = target.transform;
        _tweener = transform.DOLocalMove(Vector3.zero, 1.0f);
        _tweener.onComplete = () =>
        {
            _tweener = null;
            onComplete?.Invoke();
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {

        }
    }

}
