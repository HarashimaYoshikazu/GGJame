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
    [SerializeField] GameObject _startButton;
    [SerializeField] string _inGameName = ""; //スタートした後に飛ぶシーン名を入れる
    [SerializeField] float _fadeTime;
    [SerializeField] GameObject _titleBackImage;
    [SerializeField] Image _titleImage;

    [Header("Audioボタン")]
    [SerializeField] Button _audioButton;
    [SerializeField] GameObject _audioCanvas;
    [SerializeField] GameObject _backLight1;

    [Header("やり方説明ボタン")]
    [SerializeField] Button _ruleButton;
    [SerializeField] GameObject _ruleCanvas;
    [SerializeField] GameObject _backLight2;

    [Header("ランキングボタン")]
    [SerializeField] Button _runkButton;
    [SerializeField] GameObject _rankCanvas;
    [SerializeField] GameObject _backLight3;

    [Header("クレジット")]
    [SerializeField] Button _creditButton;
    [SerializeField] GameObject _creditCanvas;
    [SerializeField] GameObject _backLight4;

    [Header("フェードイメージ")]
    [SerializeField] private Transform _fadeTransform;

    int _selectButton = -1;

    void Start()
    {
        _fadeTransform.localScale = new Vector3(3f,3f,3f);
    }
    public void OnClickStart()
    {
        DOFadeLoadScene(1f);
    }

    public void OnClickAudio(int num)
    {
        if (_selectButton != num)
        {
            _titleBackImage.SetActive(false);
            _titleImage.color = new Color32(135, 135, 145, 70);

            _backLight1.SetActive(true);
            _backLight2.SetActive(true);
            _backLight3.SetActive(true);
            _backLight4.SetActive(true);

            _audioCanvas.SetActive(true);
            _rankCanvas.SetActive(false);
            _ruleCanvas.SetActive(false);
            _creditCanvas.SetActive(false);
            _startButton.SetActive(false);

            _backLight2.SetActive(false);
            _backLight3.SetActive(false);
            _backLight4.SetActive(false);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            _selectButton = num;
        }
        else
        {
            _titleBackImage.SetActive(true);
            _titleImage.color = new Color32(255, 255, 255, 255);

            _audioCanvas.SetActive(false);
            _startButton.SetActive(true);

            _backLight2.SetActive(true);
            _backLight3.SetActive(true);
            _backLight4.SetActive(true);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            _selectButton = -1;
        }
    }

    public void OnClickRank(int num)
    {
        if (_selectButton != num)
        {
            _titleBackImage.SetActive(false);
            _titleImage.color = new Color32(135, 135, 145, 70);

            _backLight1.SetActive(true);
            _backLight2.SetActive(true);
            _backLight3.SetActive(true);
            _backLight4.SetActive(true);

            _audioCanvas.SetActive(false);
            _rankCanvas.SetActive(true);
            _ruleCanvas.SetActive(false);
            _creditCanvas.SetActive(false);
            _startButton.SetActive(false);

            _backLight1.SetActive(false);
            _backLight2.SetActive(false);
            _backLight4.SetActive(false);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            _selectButton = num;
        }
        else
        {
            _titleBackImage.SetActive(true);
            _titleImage.color = new Color32(255, 255, 255, 255);

            _rankCanvas.SetActive(false);
            _startButton.SetActive(true);

            _backLight1.SetActive(true);
            _backLight2.SetActive(true);
            _backLight4.SetActive(true);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            _selectButton = -1;
        }
    }

    public void OnClickRule(int num)
    {
        if (_selectButton != num)
        {
            _titleBackImage.SetActive(false);
            _titleImage.color = new Color32(135, 135, 145, 70);

            _backLight1.SetActive(true);
            _backLight2.SetActive(true);
            _backLight3.SetActive(true);
            _backLight4.SetActive(true);

            _audioCanvas.SetActive(false);
            _rankCanvas.SetActive(false);
            _creditCanvas.SetActive(false);
            _ruleCanvas.SetActive(true);
            _startButton.SetActive(false);

            _backLight1.SetActive(false);
            _backLight3.SetActive(false);
            _backLight4.SetActive(false);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            _selectButton = num;
        }
        else
        {
            _titleBackImage.SetActive(true);
            _titleImage.color = new Color32(255, 255, 255, 255);

            _ruleCanvas.SetActive(false);
            _startButton.SetActive(true);

            _backLight1.SetActive(true);
            _backLight3.SetActive(true);
            _backLight4.SetActive(true);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            _selectButton = -1;
        }
    }

    public void OnClickcCedit(int num)
    {
        if (_selectButton != num)
        {
            _titleBackImage.SetActive(false);
            _titleImage.color = new Color32(135, 135, 145, 70);

            _backLight1.SetActive(true);
            _backLight2.SetActive(true);
            _backLight3.SetActive(true);
            _backLight4.SetActive(true);

            _audioCanvas.SetActive(false);
            _rankCanvas.SetActive(false);
            _ruleCanvas.SetActive(false);
            _creditCanvas.SetActive(true);
            _startButton.SetActive(false);

            _backLight1.SetActive(false);
            _backLight2.SetActive(false);
            _backLight3.SetActive(false);
            
            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            _selectButton = num;
        }
        else
        {
            _titleBackImage.SetActive(true);
            _titleImage.color = new Color32(255, 255, 255, 255);

            _creditCanvas.SetActive(false);
            _startButton.SetActive(true);

            _backLight1.SetActive(true);
            _backLight2.SetActive(true);
            _backLight3.SetActive(true);

            _audioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _runkButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _ruleButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            _creditButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            _selectButton = -1;
        }
    }

    public void DOFadeLoadScene(float color)
    {
        //_fadeImageWhite.DOFillAmount(color, _fadeTime).SetEase(Ease.OutQuint).OnComplete(() => SceneManager.LoadScene(_inGameName));
        DOTween.Sequence()
            .Append(_fadeTransform.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.Linear))
            .AppendInterval(0.5f)
            .Append(_fadeTransform.DOScale(Vector3.zero, 1f).SetEase(Ease.Linear)
            .OnComplete(() => SceneManager.LoadScene(_inGameName)));
    }
}
