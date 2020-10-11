using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPresenter : MonoBehaviour
{
    public TextMeshProUGUI m_ScoreText = null;
    public TextMeshProUGUI m_HighScoreText = null;

    void Start()
    {
        var Score = PlayerPrefs.GetInt("Score");
        var highScore = PlayerPrefs.GetInt("HighScore");

        m_ScoreText.text = $"{Score}";
        m_HighScoreText.text = $"{highScore}";
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
