using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
 

public class Pigeon : AnimalsBase
{
    public List<AnimalsBase> lsPigeon;
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
        if(lsPigeon.Count > 0)
        {
            lsPigeon.Clear();   
        }
        foreach (var animal in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if(animal.animalsName == AnimalsName.Pigeon && animal != this)
            {
                lsPigeon.Add(animal);
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
           foreach(var item in lsPigeon)
            {
                if(item.gameObject.activeSelf)
                {
                    yield return this.transform.DOMove(item.postYardBase.transform.position, 0.3f).WaitForCompletion();
                    yield return this.transform.DOJump(this.transform.position, 1.5f, 1, 0.3f).WaitForCompletion();
                    yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
                 
                }
            }
            yield return this.transform.DOMove(postYardBase.transform.position, 0.3f).WaitForCompletion();

        }
 
        yield return null;
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
    }


}
