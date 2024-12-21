using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acapela : AnimalsBase
{
    public List<AnimalsBase> lsAnimalsPlusCoin;
     
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
        lsAnimalsPlusCoin = new List<AnimalsBase>();
       foreach (var item in postYardBase.lsNearYard)
        {
            if(postYardBase.animalsBase != null && !postYardBase.animalsBase != this)
            {

                lsAnimalsPlusCoin.Add(postYardBase.animalsBase);
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
            foreach(var item in lsAnimalsPlusCoin)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, item.transform.position));
            }
        }
        yield return null;
    }


}
