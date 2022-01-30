using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGame : MonoBehaviour
{
    [SerializeField] private Text _Score;
    [SerializeField] private Button _StartButton;
    [SerializeField] private Image _fadeImage;

    private Tween _ScoreTween = null;
    private int _currentDispScore = 0;

    private void Awake()
    {
        _fadeImage.enabled = true;
    }

    public void Setup()
    {
        GameManager.Instance.OnAddScore += UpdateScore;
        _StartButton.onClick.AddListener(() =>
        {
            MapManager.I.CanStageMove = true;
            _StartButton.gameObject.SetActive(false);
        });
    }

    public void UpdateScore(int score)
    {
        DOTween.Kill(_ScoreTween);
        _fadeImage.DOFillAmount(0f, 0.5f).SetEase(Ease.Linear);
        _ScoreTween = DOTween.To(() => _currentDispScore, (val) =>
        {
            _currentDispScore = val;
            _Score.text = val.ToString("000");
        }, score, 1f);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnAddScore -= UpdateScore;
    }
}
