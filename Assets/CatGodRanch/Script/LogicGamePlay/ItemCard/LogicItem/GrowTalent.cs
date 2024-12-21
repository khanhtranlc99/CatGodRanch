using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrowTalent : ItemBase
{
    bool isInit = false;
    public TMP_Text tmp_Text;
    int coutTimeHandleEffect;
    public override void Init()
    {
        count += 1;
        tvNum.text = count.ToString();
        if(!isInit)
        {
            isInit = true;
            coutTimeHandleEffect = 0;
            tmp_Text.text = count.ToString() + "<sprite name=\"Time\">";
        }
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        coutTimeHandleEffect += 1;
    
        if(coutTimeHandleEffect >= 6)
        {
            coutTimeHandleEffect = 0;
            foreach(var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if(item.animalsType == AnimalsType.Hoofed)
                {
                    item.coinPlus += 1;
                }
            }
            Debug.LogError("GrowTalent___");
        }
        tmp_Text.text = count.ToString() + "<sprite name=\"Time\">";
        yield return null;
    }
}
