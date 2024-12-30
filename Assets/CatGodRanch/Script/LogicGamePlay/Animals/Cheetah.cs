using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheetah : AnimalsBase
{
    public List<PostYardBase> lsAnimalsPostAround;
    bool isListen = false;
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
        if (!isListen)
        {
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.MOVE_SUGGET, HandleEffectCheetah);
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

    private void HandleEffectCheetah(object param)
    {
       
    }   


}