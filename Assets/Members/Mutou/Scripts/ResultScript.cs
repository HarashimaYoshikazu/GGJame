using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScript : MonoBehaviour
{
    //ゲームマネージャーから受け取ったスコアの変数に応じて、表示するテキストを変更
    [SerializeField, Tooltip("リザルト表示時に表示されるテキスト")] Text _resultText = default;
    [SerializeField, Tooltip("リザルトを表示するパネル")] Image _resultPanel = default;
    [SerializeField, Tooltip("テキストを分岐させる時の値")] Vector2Int _judgeNumber = default;
    [SerializeField, Tooltip("表示させるテキストの内容")] string[] _popUpText = new string[3];
    [SerializeField] int num = 0;

    private void Start()
    {
        if (_resultPanel)
        {
            _resultPanel.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// リザルトのパネルを表示させる関数
    /// </summary>
    public void ViewResult()
    {
        if (_resultPanel)
        {
            _resultPanel.gameObject.SetActive(true);
            var score = num;//後でゲームマネージャーからスコアの変数をもらう

            if (0 <= score && score < _judgeNumber.x)//ここで表示させるテキストをスコアによって変化させる
            {
                _resultText.text = _popUpText[0];
            }
            else if (_judgeNumber.x <= score && score < _judgeNumber.y)
            {
                _resultText.text = _popUpText[1];
            }
            else
            {
                _resultText.text = _popUpText[2];
            }
        }
    }
}
