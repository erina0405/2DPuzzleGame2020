using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class LimitTimeCountViewer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TimeText = null;
  
        public float m_limitTime = 0f;

    //DevilOrbに触れると5秒縮む
    public float MinusSeconds = 5f;

    //3コンボより多く消した時に5秒追加
    public float PlusSeconds = 5f;

    private void Start()
    {
        m_limitTime = 60f;
    }

    public void MinusTime()
    {
        m_limitTime -= MinusSeconds;
    }

    public void PlusTime()
    {
        m_limitTime += PlusSeconds;
    }

    private void Update()
    {
        //1秒に1秒ずつ減らしていく
        m_limitTime -= Time.deltaTime;
        //マイナスは表示しない
        if (m_limitTime < 0) m_limitTime = 0;
        m_TimeText.text = $"{m_limitTime}";

        
            
    }
}
