using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PenguinCard : CardBase
{
    public List<ItemName> lsItemCondition;
    public override bool CanShow()
    {
        if(CheckItem && CheckNumbOfAnimals)
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

    public bool CheckNumbOfAnimals
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
            if (coutYard > 12)
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

            int coutItem = 0;
            foreach (var item in GamePlayController.Instance.playerContain.itemController.lsCurrentItem)
            {
                if (lsItemCondition.Contains(item.itemName))
                {
                    coutItem += 1;
                }
            }
            if (coutItem >= 2)
            {
                return true;
            }
            return false;
        }
    }


}
