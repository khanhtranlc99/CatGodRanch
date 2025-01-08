using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
public class Hyena : AnimalsBase
{
    bool isListen = false;
    public List<AnimalsBase> lsHunt;
     AnimalsBase tempHunt;
    public override void Init()
    {
        SetUpPlus();
        if (!isListen)
        {
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.HUNT_SUGGET, HandleEffectHunt);
            isListen = true;
        }
        if(lsHunt.Count > 0)
        {
            lsHunt.Clear();
        }    
        foreach (var item in postYardBase.lsNearYard)
        {
            if (item.animalsBase != null)
            {
                if (item.animalsBase.animalsName == AnimalsName.Tiger)
                {
                    lsHunt.Add( item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.Wolf)
                {
                    lsHunt.Add(item.animalsBase);
                }
                if (item.animalsBase.animalsName == AnimalsName.Fox)
                {
                    lsHunt.Add(item.animalsBase);
                }
            }

        }
    }

    public override void InitState()
    {
      
    }


    public override void HandleActionDie()
    {
        base.HandleActionDie();
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectHunt);
        isListen = false;
    }


    public override IEnumerator HandleEffect()
    {
        yield return null;
    }

    private void HandleEffectHunt(object param)
    {
        tempHunt = (AnimalsBase)param;
        if(tempHunt == null )
        {
            return;
        }
        if (lsHunt.Contains(tempHunt))
        {
            var ran = Random.Range(0,2);
            if(ran == 0)
            {
                transform.DOMove(tempHunt.gameObject.transform.position, 0.3f).OnComplete(delegate
                {
                    transform.DOMove(postYardBase.gameObject.transform.position, 0.3f).OnComplete(delegate
                    {
                        if (tempHunt != null)
                        {
                            tempHunt.HandleActionDie();
                        }     
                        StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(3, transform.position));
                    });
                });
            }    
        }    
    }

    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectHunt);
    }
}