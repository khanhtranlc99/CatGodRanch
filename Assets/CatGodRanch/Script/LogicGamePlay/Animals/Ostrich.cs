using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostrich : AnimalsBase
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
    public PostYardBase postYardJump;
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
        postYardJump = null;
        foreach (var item in postYardBase.lsNearYard)
        {
            if(item.animalsBase == null)
            {
                postYardJump = item;
                postYardJump.wasStay = true;
                break;
            }
        }
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {
            if (postYardJump != null)
            {
                yield return this.gameObject.transform.DOJump(postYardJump.transform.position, 0.5f, 1, 0.5f).OnComplete(delegate {

                    postYardBase.animalsBase = null;
                    postYardBase = null;
                    postYardBase = postYardJump;
                    postYardBase.animalsBase = this;
                    StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
                }).WaitForCompletion();

            }
        }
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
        EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.ANIMALS_MOVE, this.gameObject);
        yield return null;
    }
}
