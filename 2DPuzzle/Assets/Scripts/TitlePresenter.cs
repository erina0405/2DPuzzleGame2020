using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitlePresenter : MonoBehaviour
{
  

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameMain");
    }

}
