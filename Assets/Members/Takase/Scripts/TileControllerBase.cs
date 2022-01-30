using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class TileControllerBase : MonoBehaviour, IPointerDownHandler
{
    private const float PlayerDistance = 200 * 1.5f;

    [SerializeField] private Image _CoveredImage;

    [SerializeField] private Animator _Animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        var player = MainManager.I?.Player;
        if (player == null)
        {
            return;
        }

        var diff = transform.position.x - player.transform.position.x;
        if (diff > 0 && diff < PlayerDistance)
        {
            player.Move(transform, OnBeginTileEffect);
        }
    }

    private void OnBeginTileEffect()
    {
        if (_Animator)
        {
            _Animator.SetTrigger("Destroy");
        }

        TileEffect();
    }

    protected abstract void TileEffect();

    public void SetVisibleCoverdImage(bool isVisible)
    {
        _CoveredImage.gameObject.SetActive(isVisible);
    }
}
