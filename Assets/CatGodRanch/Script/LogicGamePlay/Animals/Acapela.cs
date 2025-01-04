using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        SetUpPlus();
        lsAnimalsPlusCoin = new List<AnimalsBase>();
       foreach (var item in postYardBase.lsNearYard)
        {
            if(item.animalsBase != null  )
            {

                lsAnimalsPlusCoin.Add(item.animalsBase);
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
            yield return this.transform.DOJump(this.transform.position, 1.5f, 1, 0.5f).WaitForCompletion();
            foreach (var item in lsAnimalsPlusCoin)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, item.transform.position));
            }
        }
        yield return null;
    }


}
