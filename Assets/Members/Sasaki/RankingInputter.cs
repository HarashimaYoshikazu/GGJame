using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingInputter : MonoBehaviour
{
    [SerializeField] Image _panel;
    [SerializeField] int _nameCapacity = 7;
    [SerializeField] Text _inputTxt;
    [SerializeField] Text _scoreTxt;

    public string Name { get; private set; }
    public bool IsSet { get; private set; }

    public void SetData(int score)
    {
        _panel.gameObject.SetActive(true);
        _scoreTxt.text = $"Score : {score}";
    }

    public void OnClick()
    {
        if (_inputTxt.text.Length >= _nameCapacity || _inputTxt.text.Length <= 0)
        {
            Debug.Log("NotMatch Capacity");
            return;
        }

        Name = _inputTxt.text;
        _panel.gameObject.SetActive(false);

        IsSet = true;
    }
}
