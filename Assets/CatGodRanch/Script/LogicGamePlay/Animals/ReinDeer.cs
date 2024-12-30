using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinDeer : AnimalsBase
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
    public AnimalsBase animalsTarget;
    bool huntSuccess;

    public override void Init()
    {
        SetUpPlus();
        huntSuccess = false;
        animalsTarget = null;
       
        foreach (var item in postYardBase.lsNearYard)
        {
            if (item.animalsBase != null)
            {
                if (item.animalsBase.animalsRank  == CardRank.Normal && item.animalsBase.huntAnimal == null)
                {
                    animalsTarget = item.animalsBase;
                    item.animalsBase.huntAnimal = this;
                    break;
                }
                if (item.animalsBase.animalsRank == CardRank.Rare && item.animalsBase.huntAnimal == null)
                {
                    animalsTarget = item.animalsBase;
                    item.animalsBase.huntAnimal = this;
                    break;
                }

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
            if(animalsTarget != null)
            {
                var temp = animalsTarget.coinPlus; 
                animalsTarget.HandleActionDie();
                animalsTarget = null;
                temp *= Random.Range(3, 7);
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
            }    
         
        }
        yield return null;
    }
}
