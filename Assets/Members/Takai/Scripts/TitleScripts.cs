using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScripts : MonoBehaviour
{
    [Header("メインキャンバス")]
    [SerializeField] GameObject _mainCanvas;

    [Header("スタートボタン")]
    [SerializeField] Button _startButton;

    [Header("Audioボタン")]
    [SerializeField] Button _audioButton;
    [SerializeField] GameObject _audioCanvas;

    [Header("やり方説明ボタン")]
    [SerializeField] Button _ruleButton;
    [SerializeField] GameObject _ruleCanvas;

    [Header("もどるボタン")]
    [SerializeField] Button _backButton;

    public void OnClickStart()
    {

    }

    public void OnClickAudio()
    {
        _mainCanvas.SetActive(false);
        _audioCanvas.SetActive(true);
    }

    public void OnClickRule()
    {
        _mainCanvas.SetActive(false);
        _ruleCanvas.SetActive(true);
    }

    public void OnClickBack()
    {
        _audioCanvas.SetActive(false);
        _ruleCanvas.SetActive(false);
        _mainCanvas.SetActive(true);
    }
}
