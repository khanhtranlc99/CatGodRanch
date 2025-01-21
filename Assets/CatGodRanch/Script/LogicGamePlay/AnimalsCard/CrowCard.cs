using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowCard : CardBase
{
    public override bool CanShow()
    {          
       if (CheckItem && CheckNumbOfAnimals)
        {
         return true;
        }       
        return false;
    }
    public override void Init()
    {

    }
    public override void HandleAction()
    {

    }
    private bool CheckNumbOfAnimals
    {
        get
        {
            int coutYard = 0;
            foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if (item.animalsBase != null)
                {
                    coutYard += 1;
                }
            }
            if (coutYard > 14)
            {
                return true;
            }
            return false;
        }

    }

    private bool CheckItem
    {
        get
        {

            if (GamePlayController.Instance.playerContain.itemController.lsCurrentItem.Count >= 1)
            {

                return true;

            }
            return false;
        }
    }

}

