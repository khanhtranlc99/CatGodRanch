using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocodileCard : CardBase
{
    public override bool CanShow()
    {
        if(CheckItem)
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
    private bool CheckItem
    {
        get
        {
            int countGrass = 0;

            foreach (var item in GamePlayController.Instance.playerContain.itemController.lsCurrentItem)
            {
                if (item.itemName == ItemName.Puddle)
                {
                    countGrass += item.count;
                }


            }
            if (countGrass >= 1)
            {
                return true;
            }
            return false;
        }
    }

}

