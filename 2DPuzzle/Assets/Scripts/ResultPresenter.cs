using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultPresenter : MonoBehaviour
{
    public TextMeshProUGUI m_ScoreText;

    void Start()
    {
        var Score = PlayerPrefs.GetInt("Score");
        m_ScoreText.text = $"{Score}";
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
