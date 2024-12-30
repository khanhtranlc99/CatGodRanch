using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pig : AnimalsBase
{
    public TMP_Text tvDay;
    int day = 3;
    public override void Init()
    {
        SetUpPlus();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }

    public override void InitState()
    {
    
    }

  





    public override IEnumerator HandleEffect()
    {
        day -= 1;
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        if (day <= 0)
        {
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(12, transform.position));
            base.HandleActionDie();
        }
        yield return null;
    }


}
