using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleLion : AnimalsBase
{
    public AnimalsBase animalsTarget;
    bool huntSuccess;
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
        huntSuccess = false;
        animalsTarget = null;

        foreach (var item in postYardBase.lsNearYard)
        {
            if (item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Hoofed && item.animalsBase.huntAnimal == null)
            {
                item.animalsBase.huntAnimal = this;
                animalsTarget = item.animalsBase;
                break;
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
            if (animalsTarget != null)
            {
                if (animalsTarget.lsAnimalsProtect.Count > 0)
                {
                    huntSuccess = false;
                    yield return transform.DOMove(animalsTarget.gameObject.transform.position, 0.5f).WaitForCompletion();
                    foreach (var item in animalsTarget.lsAnimalsProtect)
                    {
                        yield return StartCoroutine(item.HandleActionProtect());
                    }
                    animalsTarget = null;
                    yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();
                }
                else
                {
                    huntSuccess = true;
                    yield return transform.DOMove(animalsTarget.gameObject.transform.position, 0.5f).WaitForCompletion();
                    animalsTarget.HandleActionDie();
                    animalsTarget = null;
                    yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();

                    yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(3, transform.position));

                }
            }
            yield return null;
            if (huntSuccess)
            {
                EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.HUNT_SUGGET, this);
                EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.FEMALE_LION_HUNT_SUGGET, this);
            }
        }
        else
        {
            yield return null;
        }
    }
}
