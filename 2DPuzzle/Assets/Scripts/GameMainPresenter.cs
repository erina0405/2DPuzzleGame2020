using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMainPresenter : MonoBehaviour
{
    public ScoreViewer m_scoreViewer = null;

    public LimitTimeCountViewer m_limitTimeCountViewer = null;

    private void Update()
    {
        if (m_limitTimeCountViewer.m_limitTime == 0)
        {
            GotoResult();
        }
    }

    private void GotoResult()
    {
        //保存されているハイスコアより今回のScoreが高い場合
        if (PlayerPrefs.GetInt("HighScore", 0) != 0)
        {
            if (PlayerPrefs.GetInt("HighScore") < m_scoreViewer.Score)
            {
                PlayerPrefs.SetInt("HighScore", m_scoreViewer.Score);
            }
        }
        else
        {
            //ハイスコアが保存されていない場合
            PlayerPrefs.SetInt("HighScore", m_scoreViewer.Score);
        }

        SceneManager.LoadScene("Result");
        PlayerPrefs.SetInt("Score", m_scoreViewer.Score);
        PlayerPrefs.Save();

    }
}
