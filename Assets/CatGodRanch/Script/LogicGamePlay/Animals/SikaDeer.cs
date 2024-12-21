using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SikaDeer : AnimalsBase
{
    public List<PostYardBase> lsAnimalsPostAround;
    public PostYardBase tempPostYardBase;
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
    bool isListen = false;
    public override void Init()
    {
        AnimScale();
        if (!isListen)
        {
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.HUNT_SUGGET, HandleEffectSikaDeer);
            isListen = true;
        }
      
            if (lsAnimalsPostAround.Count > 0)
            {
                lsAnimalsPostAround.Clear();
            }

            foreach (var item in postYardBase.lsNearYard)
            {
                if (item.animalsBase != null)
                {
                    lsAnimalsPostAround.Add(item);
                }
            }
     
      
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        yield return null;
    }
    private void HandleEffectSikaDeer(object param)
    {
        if (CanHandleEffect)
        {
            tempPostYardBase = null;
            foreach (var item in lsAnimalsPostAround)
            {
                if (item.animalsBase != null)
                {
                    tempPostYardBase = item;
                    break;
                }
            }
            if (tempPostYardBase != null)
            {
                this.transform.DOMove(tempPostYardBase.transform.position, 0.15f).OnComplete(delegate {
                    postYardBase.animalsBase = null;
                    postYardBase = null;
                    postYardBase = tempPostYardBase;
                    postYardBase.animalsBase = tempPostYardBase.animalsBase;
                    if (lsAnimalsPostAround.Count > 0)
                    {
                        lsAnimalsPostAround.Clear();
                    }
                    foreach (var item in postYardBase.lsNearYard)
                    {
                        if (item.animalsBase != null)
                        {
                            lsAnimalsPostAround.Add(item);
                        }
                    }
                });
            }
        }
     
    }
    public override void HandleActionDie()
    {
        base.HandleActionDie();
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectSikaDeer);
        isListen = false;
    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectSikaDeer);
    }
}