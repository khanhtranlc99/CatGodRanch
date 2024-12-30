using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : AnimalsBase
{
    public bool CheckBirdAround
    {
        get
        {
            foreach (var item in postYardBase.lsNearYard)
            {
                if (item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Bird)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public int countInt;
    public bool CanHandleEffect
    {
        get
        {
            if (huntAnimal != null && lsAnimalsProtect.Count <= 0)
            {
                return false;
            }
            return true;
        }
    }
    public override void Init()
    {
        SetUpPlus();
        countInt = 0;
        foreach (var animal in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if(animal.animalsName == AnimalsName.Pigeon)
            {
                countInt += 1;
            }    
        }    
       
    }

    public override void InitState()
    {
   
    }






    public override IEnumerator HandleEffect()
    {
        if (CanHandleEffect)
        {
            if (countInt >= 3)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
            }
        }
 
        yield return null;
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
    }


}
