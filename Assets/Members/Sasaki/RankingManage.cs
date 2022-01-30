using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using NCMB;

public class RankingManage : MonoBehaviour
{
    [SerializeField] GameObject _rankingCanvas;
    [SerializeField] Image _rankingPanel;
    [SerializeField] int _getTopCount = 10;
    [SerializeField] TextMeshProUGUI _rankingTxt; 

    const string DataStore = "Ranking";
    const string User= "UserName";
    const string ScoreData = "Score";

    RankingInputter _inputter;
    bool _isRankIn = false;

    /// <summary>
    /// Rankingの表示のみ
    /// </summary>
    public void LoadRanking()
    {
        SetRanking();
    }

    /// <summary>
    /// NCMBにScoreを伝える
    /// </summary>
    /// <param name="score">Score</param>
    public void GetScore(int score)
    {
        _rankingCanvas.SetActive(true);
        _inputter = GetComponent<RankingInputter>();

        SetRanking(score);
    }

    void SetRanking(int score = 0)
    {
        _rankingPanel.gameObject.SetActive(true);
        _isRankIn = false;
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(DataStore);
        query.OrderByDescending(ScoreData);
        query.Limit = _getTopCount;

        query.FindAsync((objList, e) => 
        {
            if (e != null) Debug.Log($"{e.ErrorMessage}");
            else
            {
                Debug.Log("IsFind");
                if (score > 0 && objList.Count < query.Limit 
                || score > int.Parse(objList[objList.Count - 1][ScoreData].ToString())
                || objList.Count == 0)
                {
                    Debug.Log("IsRankIn");
                    _isRankIn = true;
                    StartCoroutine(WaitInputName(score));
                    SetRankingText(objList);
                }
                else
                {
                    Debug.Log("NotRankIn");
                    _isRankIn = false;
                    SetRankingText(objList);
                }

            }
        });
    }

    IEnumerator WaitInputName(int score)
    {
        _inputter.SetData(score);
        yield return new WaitUntil(() => _inputter.IsSet);
        SaveScore(score);
    }

    void SaveScore(int score)
    {
        NCMBObject nObj = new NCMBObject(DataStore);
        nObj[User] = _inputter.Name;
        nObj[ScoreData] = score;

        nObj.SaveAsync(e =>
        {
            if (e != null) Debug.Log($"Can't Saved \n {e.ErrorMessage}");
            else
            {
                Debug.Log("IsSaved");
                NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(DataStore);
                query.FindAsync((objList, e) =>
                {
                    if (e != null) Debug.Log($"Can't Find \n {e.ErrorMessage}");
                    else SetRankingText(objList);
                });
            }
        });
    }

    void SetRankingText(List<NCMBObject> objList)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(" " + "rank");
        builder.Append(":");
        builder.Append(User);
        builder.Append(":");
        builder.Append(ScoreData);
        builder.Append("\n");
        for (int i = 0; i < objList.Count; i++)
        {
            builder.Append(" " + (i + 1).ToString());
            builder.Append(":");
            builder.Append(objList[i][User].ToString());
            builder.Append(":");
            builder.Append(objList[i][ScoreData].ToString());
            builder.Append("\n");
        }

        _rankingTxt.text = builder.ToString();
        GameManager.Instance.Init();
    }

    public bool IsRankIn() => _isRankIn;
}
