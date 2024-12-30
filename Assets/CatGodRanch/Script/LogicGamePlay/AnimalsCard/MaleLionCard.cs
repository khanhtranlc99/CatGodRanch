using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class MaleLionCard : CardBase
{
    public override bool CanShow()
    {
        if(Condition)
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
     private bool Condition
    {
        get
        {
            int CountFemaleLion = 0;
        
            foreach(var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if(item.animalsName == AnimalsName.FemaleLion)
                {
                    CountFemaleLion += 1;
                }
          
            }    
            if(CountFemaleLion >= 1)
            {
                return true;
            }
       
          
            return false ;
        }
    }    

}

