using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinDeerCard : CardBase
{
 
    public override bool CanShow()
    {
        if(GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Count >= 18)
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


}
