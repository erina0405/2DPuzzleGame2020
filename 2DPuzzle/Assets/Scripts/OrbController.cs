using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class OrbController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private SpriteRenderer m_spriteRenderer = null;

    public ComboCounter comboCounter = null;


    public enum OrbType
    {
        Invalid = -1,
        BlueOrb,
        GreenOrb,
        RedOrb,
        YellowOrb,
        DevilOrb,
        SpecialOrb,
    }

    public OrbType ThisOrbType = OrbType.Invalid;

    public ParticleSystem ComboEffect = null;

    public OrbGenerater orbGenerater = null;

    public LimitTimeCountViewer LimitTimeCountViewer = null;

    public ScoreViewer ScoreViewer = null;

    //6秒でDevilOrbが消える
    private float m_devilOrbDisapperSeconds = 6f;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();

                ComboEffect.gameObject.SetActive(false);

    }

    private void Update()
    {
        if(ThisOrbType == OrbType.DevilOrb)
        {
            m_devilOrbDisapperSeconds -= Time.deltaTime;

            if(m_devilOrbDisapperSeconds <= 0)
            {
                orbGenerater.OrbGenerate(1);
                this.gameObject.SetActive(false);
            }
        }
    }

    //ShuffleActionの実装
    public void ShuffleAction()
    {
        this.GetComponent<Rigidbody2D>().
            AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode2D. Impulse);
    }

    //DevilActionの実装
    public void DevilAction()
    {
        LimitTimeCountViewer.MinusTime();
        ScoreViewer.MinusScore();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(ThisOrbType == OrbType.DevilOrb)
        {
            DevilAction();
            return;
        }

        comboCounter.AddCombo(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(ThisOrbType == OrbType.DevilOrb)
        {
            DevilAction();
            return;
        }
        
        if (comboCounter.DragObjList.Count.Equals(0))
        {
            return;
        }

        //リストの中に自分がいたらかえる
        foreach (var thisOrb in comboCounter.DragObjList)
        {
            if (thisOrb == this.gameObject)
            {
                return;
            }
        }

        if(ThisOrbType == OrbType.SpecialOrb ||
            comboCounter.DragObjList.LastOrDefault().GetComponent<OrbController>().
            ThisOrbType == OrbType.SpecialOrb)
        {
            comboCounter.AddCombo(this.gameObject);
            return;
        }

        
        if (!comboCounter.CheckCombo(this.transform))
        {
            return;
        }

   
        if (comboCounter.DragObjList.Contains(this.gameObject))
        {
            if (comboCounter.DragObjList.Count.Equals(1))
            {
                return;
            }

            comboCounter.MinusCombo();
            return;
        }

        if (comboCounter.DragObjList.FirstOrDefault().GetComponent<OrbController>().ThisOrbType != ThisOrbType)
        {
            return;
        }


        comboCounter.AddCombo(this.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (comboCounter.ComboCount > 2)
        {
            foreach (var orb in comboCounter.DragObjList)
            {
                orb.SetActive(false);
            }

            orbGenerater.OrbGenerate(comboCounter.ComboCount);

        }
        comboCounter.ClearCombo();
    }
}


