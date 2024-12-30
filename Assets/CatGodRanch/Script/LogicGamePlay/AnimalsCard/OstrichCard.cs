using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OstrichCard : CardBase
{
    public override bool CanShow()
    {
         if(GamePlayController.Instance.playerContain.itemController.lsCurrentItem.Count > 0)
        {
            int coutEmptyYard = 0;
            foreach(var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if (item.animalsBase == null)
                {
                    coutEmptyYard += 1;
                }
            }
            if(coutEmptyYard >= 2)
            {
                return true;
            }

        }

        return false;
    }
    public override void Init()
    {

    }
    public override void HandleAction()
    {

    }


}

