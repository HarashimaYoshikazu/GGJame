using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Sounds;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    [SerializeField] private Transform _PlayerInCircle;
    [SerializeField] private Transform _PlayerOutCircle;
    [SerializeField] private CanvasGroup _PlayerCanvasGroup;

    private Tween _tweener;

    private float _Timer = 1.0f;

    [SerializeField] private Transform m_MoveTarget;

    private bool _isDied = false;

    private void Start()
    {
        _isDied = false;
        //回転を無限ループさせる
        _PlayerInCircle.transform.DOLocalRotate(new Vector3(0, 0, 360f), 5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        _PlayerOutCircle.transform.DOLocalRotate(new Vector3(0, 0, -360f), 5f, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
        _PlayerOutCircle.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 0.2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void Reset()
    {
        _Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_tweener == null && m_MoveTarget)
        {
            transform.position = m_MoveTarget.position;
        }

        if (transform.position.x < 50f)
        {
            PlayerDiedAnime(() => GameManager.Instance.ChangeState(GameState.Result));
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

        _PlayerOutCircle.transform.DOScale(new Vector3(2f, 2f, 1f), 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear);

        m_MoveTarget = target;
        _tweener = transform.DOMove(target.position, 0.2f);
        _tweener.onComplete = () =>
        {
            _tweener = null;
            onComplete?.Invoke();
            _Timer = 1.0f;
        };
    }

    /// <summary>
    /// 死亡時演出処理
    /// </summary>
    public void PlayerDiedAnime(System.Action compriteCallback)
    {
        if (_isDied)
            return;

        _isDied = true;
        MainManager.I.MapManager.ChangeVisibleAllTiles(false);
        SoundManager.Request(1, SoundGroupID.SE);
        _PlayerInCircle.DOPause();
        _PlayerOutCircle.DOPause();
        _PlayerCanvasGroup.DOFade(0f, 1.0f).SetEase(Ease.OutSine);
        transform.DOScale(20.0f, 1.0f).SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                compriteCallback();
            });
    }
}
