using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioSource[] m_audioSource = new AudioSource[2];

    public AudioClip BombSE = null;

    public AudioClip BGM = null;

    private void Start()
    {
        m_audioSource[1].clip = BGM;
        m_audioSource[1].loop = true;
        m_audioSource[1].Play();
    }


    public void PlaySE()
    {
        m_audioSource[0].clip = BombSE;
        m_audioSource[0].Play();
    }


}
