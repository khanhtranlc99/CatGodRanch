using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Coyote : AnimalsBase
{
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
        AnimScale();
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {

            int countCarnivore = 0;
            // Đếm số lượng mỗi loại AnimalsName
            foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if(item.animalsType == AnimalsType.Carnivore)
                {
                    countCarnivore += 1;
                }
            }
            if (countCarnivore >= 3)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, transform.position));
            }
            else
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(-1, transform.position));
            }    
         
        }
        yield return null;
    }
}
