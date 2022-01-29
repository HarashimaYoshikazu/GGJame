using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIGame : MonoBehaviour
{
    [SerializeField] private Text _Score;

    private Tween _ScoreTween = null;
    private int _currentDispScore = 0;

    public void Setup()
    {
        GameManager.Instance.OnAddScore += UpdateScore;
    }

    public void UpdateScore(int score)
    {
        DOTween.Kill(_ScoreTween);
        _ScoreTween = DOTween.To(() => _currentDispScore, (val) =>
        {
            _currentDispScore = val;
            _Score.text = string.Format("{0:#,0}", val);
        }, score, 1f);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnAddScore -= UpdateScore;
    }
}
