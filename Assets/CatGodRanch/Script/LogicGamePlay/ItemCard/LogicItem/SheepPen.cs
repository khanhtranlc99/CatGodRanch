using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SheepPen : ItemBase
{
    bool isInit = false;
    public TMP_Text tmp_Text;
    int coutTimeHandleEffect;
    public GameObject sheepObj;
    public override void Init()
    { 
        count += 1;
        if (count > 1)
        {
            tvNum.text = count.ToString();
        }
        if (!isInit)
        {
            isInit = true;
            coutTimeHandleEffect = 3;
            tmp_Text.text = coutTimeHandleEffect.ToString() + "<sprite name=\"Time\">";
        }
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        coutTimeHandleEffect -= 1;

        if (coutTimeHandleEffect < 1)
        {
            coutTimeHandleEffect = 3;
            GamePlayController.Instance.playerContain.animalController.SpwanAnimals(sheepObj);

        }
        tmp_Text.text = coutTimeHandleEffect.ToString() + "<sprite name=\"Time\">";
        yield return null;
    }
}
