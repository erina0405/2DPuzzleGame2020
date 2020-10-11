using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ComboCounter : MonoBehaviour
{
    public List<GameObject> DragObjList = new List<GameObject>();

    public int ComboCount => DragObjList.Count;

    public OrbGenerater m_OrbGenerater = null;

    public int CurrentComboCount;

    public  SEManager m_SEManager;

    [SerializeField] private LimitTimeCountViewer limitTimeCountViewer = null;

    public void AddCombo(GameObject orb)
    {
        DragObjList.Add(orb);

        foreach (var orbs in DragObjList)
        {
            if (!orbs.GetComponent<OrbController>().ComboEffect.gameObject.activeSelf)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.SetActive(true);
            }

        }

    }

    public void MinusCombo()
    {
        DragObjList.LastOrDefault().GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);
        DragObjList.Remove(DragObjList.LastOrDefault());
    }

    public void ClearCombo()
    {
        //todo;コンボが4より大きければ秒数を増やす
        if(DragObjList.Count>4)
        {
            limitTimeCountViewer.PlusTime();
        }

        if (DragObjList.Count>2)
        {
            m_SEManager.PlaySE();
        }

        foreach (var orbs in DragObjList)
        {
            if (orbs.GetComponent<OrbController>().ComboEffect.gameObject.activeSelf)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);
            }
            CurrentComboCount++;

        }

       

        DragObjList.Clear();
        
    }

    public bool CheckCombo(Transform thisOrbTransform)
    {
        //DragObjListの最後のobjectと次に入ってくるthisOrbTransformとの距離
        var distance = Vector2.Distance(thisOrbTransform.transform.position, DragObjList.LastOrDefault().transform.position);
        Debug.Log(distance);
        
        //距離が2以下ならtrue
        return distance <= 2f;
    }
}

