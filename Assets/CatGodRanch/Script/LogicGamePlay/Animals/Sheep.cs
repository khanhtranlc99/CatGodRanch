using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Sheep : AnimalsBase
{
    
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
    public TMP_Text tvDay;
    int day = 3;
    public override void Init()
    {
        SetUpPlus();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }

    public override void InitRange()
    {
        
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
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(7, transform.position));
                base.HandleActionDie();
            }
        }   
        yield return null;
    }


}
