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
        tvNum.text = count.ToString();
        if (!isInit)
        {
            isInit = true;
            coutTimeHandleEffect = 0;
            tmp_Text.text = count.ToString() + "<sprite name=\"Time\">";
        }
    }
    public override IEnumerator HandleEffectItemIEnumrator()
    {
        coutTimeHandleEffect += 1;

        if (coutTimeHandleEffect >= 3)
        {
            coutTimeHandleEffect = 0;
            GamePlayController.Instance.playerContain.animalController.SpwanAnimals(sheepObj);

        }
        tmp_Text.text = count.ToString() + "<sprite name=\"Time\">";
        yield return null;
    }
}
