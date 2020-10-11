using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGenerater : MonoBehaviour
{
    [SerializeField] Transform m_orbGenerater = null;

    [SerializeField] List<GameObject> m_orbObjects = new List<GameObject>();

    [SerializeField] ComboCounter m_comboCounter = null;

    private int m_maxOrbCount = 20;

    public List<GameObject> OrbList = new List<GameObject>();

    [SerializeField] private LimitTimeCountViewer LimitTimeCountViewer = null;

    [SerializeField] private ScoreViewer ScoreViewer = null;

    void Start()
    {
        OrbGenerate(m_maxOrbCount);
    }

    private int GenerateObj()
    {
        //ランダムで0から100までの値を計算できる
        var orbjudge = Random.Range(0, 101);

        switch(orbjudge)
        {
            case int i when i < 70:
                return Random.Range(0, 4);

            case int i when 70 < 80:
                return 5;

            default:
                return 6;
        }
    }

    public void OrbGenerate(int generateOrbCount)
    {
        for (int i = 0; i < generateOrbCount; i++)
        {
            var orb = Instantiate(m_orbObjects[Random.Range(0, 6)], m_orbGenerater);

            var orbController = orb.GetComponent<OrbController>();

            orb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-4, 4), Random.Range(-4, 0)));

            orb.GetComponent<OrbController>().comboCounter = m_comboCounter;
            orb.GetComponent<OrbController>().orbGenerater = this;
          


            if (orbController.ThisOrbType == OrbController.OrbType.DevilOrb)
            {
                orbController.LimitTimeCountViewer = LimitTimeCountViewer;
                orbController.ScoreViewer = ScoreViewer;
            }
            OrbList.Add(orb);
        }
    }
}
