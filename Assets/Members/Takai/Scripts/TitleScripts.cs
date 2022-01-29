using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TitleScripts : MonoBehaviour
{
    [Header("メインキャンバス")]
    [SerializeField] GameObject _mainCanvas;

    [Header("スタートボタン")]
    [SerializeField] Button _startButton;
    [SerializeField] string _inGameName = ""; //スタートした後に飛ぶシーン名を入れる

    [Header("Audioボタン")]
    [SerializeField] Button _audioButton;
    [SerializeField] GameObject _audioCanvas;

    [Header("やり方説明ボタン")]
    [SerializeField] Button _ruleButton;
    [SerializeField] GameObject _ruleCanvas;

    [Header("ランキングボタン")]
    [SerializeField] Button _runkButton;
    [SerializeField] GameObject _rankCanvas;

    [Header("もどるボタン")]
    [SerializeField] Button _backButton;

    [Header("フェードイメージ")]
    [SerializeField] Image _fadeImage;

    void Start()
    {
        _fadeImage.gameObject.SetActive(false);
    }
    public void OnClickStart()
    {
        DOFadeLoadScene(1f);
    }

    public void OnClickAudio()
    {
        _audioCanvas.SetActive(true);
    }

    public void OnClickRank()
    {
        _rankCanvas.SetActive(true);
        
    }

    public void OnClickRule()
    {
        _ruleCanvas.SetActive(true);
    }

    public void OnClickBack()
    {
        _audioCanvas.SetActive(false);
        _ruleCanvas.SetActive(false);
        _rankCanvas.SetActive(false);
    }

    public void OnClickQuit()
    {
        DoFadeImageOut(1f);
    }

    public void DoFadeImageOut(float color)
    {
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.DOFade(color, 3f).OnComplete(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
        });
    }

    public void DOFadeLoadScene(float color)
    {
        _fadeImage.gameObject.SetActive(true);
        _fadeImage.DOFade(color, 3f).OnComplete(() => SceneManager.LoadScene(_inGameName));
    }
}
