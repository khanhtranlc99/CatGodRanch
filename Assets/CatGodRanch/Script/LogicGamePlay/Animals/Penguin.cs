using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Penguin : AnimalsBase
{
    public bool CheckBirdAround
    {
        get
        {
            foreach (var item in postYardBase.lsNearYard)
            {
                if (item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Bird)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public TMP_Text tvDay;
    int day = 3;
    public bool CanHandleEffect
    {
        get
        {
            if (huntAnimal != null && lsAnimalsProtect.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }

    public override void Init()
    {
        AnimScale();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if (CanHandleEffect)
        {
            day -= 1;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            if (day <= 0)
            {
                Debug.LogError("LayItem");
            }
        }
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
        yield return null;
    }
}
