using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ComboCounter : MonoBehaviour
{
    public List<GameObject> DragObjList = new List<GameObject>();

    public int ComboCount => DragObjList.Count;

    public void AddCombo(GameObject orb)
    {
        DragObjList.Add(orb);
    }

    public void MinusCombo()
    {
        DragObjList.Remove(DragObjList.LastOrDefault());
    }

    public void ClearCombo()
    {
        DragObjList.Clear();
    }
}
