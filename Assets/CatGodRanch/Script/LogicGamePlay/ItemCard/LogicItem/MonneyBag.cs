using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonneyBag : ItemBase
{
    public override void Init()
    {
        count += 1;
        tvNum.text = count.ToString();
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        foreach(var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
        {
            if(item.animalsBase == null)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(count, item.transform.position));
            }    
        }
        yield return null;
    }
}