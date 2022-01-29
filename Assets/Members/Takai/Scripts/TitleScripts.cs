using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScripts : MonoBehaviour
{
    [Header("���C���L�����o�X")]
    [SerializeField] GameObject _mainCanvas;

    [Header("�X�^�[�g�{�^��")]
    [SerializeField] Button _startButton;

    [Header("Audio�{�^��")]
    [SerializeField] Button _audioButton;
    [SerializeField] GameObject _audioCanvas;

    [Header("���������{�^��")]
    [SerializeField] Button _ruleButton;
    [SerializeField] GameObject _ruleCanvas;

    [Header("���ǂ�{�^��")]
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
