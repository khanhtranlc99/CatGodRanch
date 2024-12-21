using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class Gazelle : AnimalsBase
{
    public PostYardBase postSwitch;
    public PostYardBase tempPostSwitch;
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
    }
    public override void InitState()
    {

    }
    public bool CheckCanSwitch (AnimalsBase animalsBase)
    {
       if(animalsBase.huntAnimal != null && animalsBase.lsAnimalsProtect.Count <= 0)
        {
            return false;
        }
        return true;
    }
    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {
            postSwitch = null;
            tempPostSwitch = null;
            foreach (var item in postYardBase.lsNearYard)
            {
                if (item.animalsBase != null && item.id < postYardBase.id)
                {
                    if (CheckCanSwitch(item.animalsBase))
                    {
                        postSwitch = item;
                       

                    }
                }
            }
            if(postSwitch != null)
            {
                tempPostSwitch = postYardBase;
                yield return this.transform.DOMove(postSwitch.transform.position, 0.35f).WaitForCompletion();
                yield return postSwitch.animalsBase.transform.DOMove(postYardBase.transform.position, 0.35f).WaitForCompletion();

                postYardBase = postSwitch;
                postYardBase.animalsBase = postSwitch.animalsBase;
                postSwitch = tempPostSwitch;
                postSwitch.animalsBase = tempPostSwitch.animalsBase;
                postSwitch.Init();
            }
         
       


        }    
        yield return null;
    }
}
