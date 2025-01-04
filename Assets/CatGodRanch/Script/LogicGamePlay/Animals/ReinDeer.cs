using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
                temp *= Random.Range(3, 7);
                var tempPost = GamePlayController.Instance.playerContain.animalController.reinDeerController.GetPost(this.transform.position, animalsTarget.transform.position);
                yield return this.transform.DOMove(animalsTarget.transform.position, 0.5f).SetEase(Ease.InBack).WaitForCompletion();
                yield return animalsTarget.transform.DOJump(tempPost.position, 1.5f, 1, 0.5f).WaitForCompletion();

                animalsTarget.HandleActionDie();
                animalsTarget = null;
                yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(temp, transform.position));
            }    
         
        }
        yield return null;
    }
}
