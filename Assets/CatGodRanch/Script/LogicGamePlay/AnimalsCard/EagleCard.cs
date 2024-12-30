using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleCard : CardBase
{
    public override bool CanShow()
    {
       if(HasCondition)
        {
            return true;
        }
        return false;
    }
    public override void Init( )
    {
   
    }
    public override void HandleAction()
    {

    }

    private bool HasCondition 
    {
        get
        {
            int coutBird = 0;
            foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if (item.animalsType == AnimalsType.Bird)
                {
                    coutBird += 1;
                }
            }
            if (coutBird >= 5)
            {
                return true;
            }
            return false;
        }
    }    

}
