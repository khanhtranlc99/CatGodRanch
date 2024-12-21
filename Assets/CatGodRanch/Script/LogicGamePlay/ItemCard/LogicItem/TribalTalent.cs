using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TribalTalent : ItemBase
{ 
 

    public override void Init()
    {
        count += 1;
        tvNum.text = count.ToString();
      
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        yield return null;
    }

    public void SpawnEffectTribalTalent(object param)
    {
     var tempBird = (GameObject)param;
     StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(count, tempBird.transform.position));
    }    

}
