using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerCard : CardBase
{
    public override bool CanShow()
    {
        if(CheckItem && HasConditionAnimals && ConditionNumb)
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
            if (GamePlayController.Instance.playerContain.itemController.lsCurrentItem.Count >= 2)
            {

                return true;

            }
            return false;
        }
    }
    public bool HasConditionAnimals
    {
        get
        {
            List<AnimalsBase> lsName = new List<AnimalsBase>();
            foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if (item.animalsType == AnimalsType.Hoofed)
                {
                    lsName.Add(item);
                }
            }


            List<AnimalsName> lsBase = new List<AnimalsName>();
            foreach (var item in lsName)
            {
                if (!lsBase.Contains(item.animalsName))
                {
                    lsBase.Add(item.animalsName);
                }
            }
            if (lsBase.Count >= 4)
            {
                return true;
            }
            return false;
        }
    }
    private bool ConditionNumb
    {
        get
        {

            if (GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Count > 8)
            {
                return true;
            }


            return false;
        }
    }

}
