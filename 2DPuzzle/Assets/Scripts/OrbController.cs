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
        Invalide = -1,
        BlueOrb,
        GreenOrb,
        RedOrb,
        YellowOrb,
    }

    public OrbType thisOrbType = OrbType.Invalide;

    public ParticleSystem ComboEffect = null;

    public OrbGenerater orbGenerater = null;

    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();


        ComboEffect.gameObject.SetActive(false);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        comboCounter.AddCombo(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (comboCounter.DragObjList.Count.Equals(0))
        {
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

        if (comboCounter.DragObjList.FirstOrDefault().GetComponent<OrbController>().thisOrbType != thisOrbType)
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


