using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitTimeCountViewer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TimeText = null;

    private float m_limitTime = 60;

    private void Start()
    {

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
