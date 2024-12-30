using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagpieCard : CardBase
{
    public override bool CanShow()
    {
        if(CheckItem && HasConditionAnimals)
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
    public bool HasConditionAnimals
    {
        get { 
        List<AnimalsBase> lsName = new List<AnimalsBase>();
        foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if (item.animalsType == AnimalsType.Bird)
            {
                lsName.Add(item);
            }
        }


        List<AnimalsName> lsBase = new List<AnimalsName> ();
        foreach(var item in lsName)
        {
            if(!lsBase.Contains(item.animalsName))
            {
                lsBase.Add(item.animalsName);
            }
        }
        if(lsBase.Count >= 3)
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
                if (item.itemName == ItemName.Nest)
                {
                    coutItem += item.count;
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
