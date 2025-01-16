using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MonneyBag : ItemBase
{
    public override void Init()
    {
        count += 1;
        if (count > 1)
        {
            tvNum.text = count.ToString();
        }
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        
        foreach(var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
        {
            if(item.animalsBase == null)
            {
                 StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(count, item.transform.position));
            }    
        }
        yield return new WaitForSeconds(0.7f);
    }
}