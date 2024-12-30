using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SikaDeerCard : CardBase
{
    public override bool CanShow()
    {
        if(CheckItem && Condition)
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
            if (GamePlayController.Instance.playerContain.itemController.lsCurrentItem.Count >= 1)
            {

                return true;

            }
            return false;
        }
    }
    private bool Condition
    {
        get
        {
            int CountHorse = 0;
            int CountGazzle = 0;
            int CoutOstrick = 0;
            foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if (item.animalsName == AnimalsName.Horse)
                {
                    CountHorse += 1;
                }
                if (item.animalsName == AnimalsName.Gazelle)
                {
                    CountGazzle += 1;
                }
                if (item.animalsName == AnimalsName.Ostrich)
                {
                    CoutOstrick += 1;
                }
            }
            if (CountHorse >= 2)
            {
                return true;
            }
            if (CountGazzle >= 2)
            {
                return true;
            }
            if (CoutOstrick >= 2)
            {
                return true;
            }

            return false;
        }
    }
}
