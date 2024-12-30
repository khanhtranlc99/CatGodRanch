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
        SetUpPlus();
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
          
            if (day <= 0)
            {

                day = 3;
                var Ran = Random.Range(0, GamePlayController.Instance.playerContain.itemController.lsCardBase.Count);
                var name = GamePlayController.Instance.playerContain.itemController.lsCardBase[Ran];
                GamePlayController.Instance.playerContain.itemController.SpawnItem(name.itemDataProperty.itemName);
            }
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
        }
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
        yield return null;
    }
}
