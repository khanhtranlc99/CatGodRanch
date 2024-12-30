using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class Gazelle : AnimalsBase
{
    public PostYardBase postSwitch;
    public PostYardBase tempPostSwitch;
    public AnimalsBase tempAnimals;
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
                tempAnimals = postYardBase.animalsBase;
                yield return this.transform.DOMove(postSwitch.transform.position, 0.35f).WaitForCompletion();
                yield return postSwitch.animalsBase.transform.DOMove(postYardBase.transform.position, 0.35f).WaitForCompletion();

                postYardBase.animalsBase = postSwitch.animalsBase;
                postYardBase.animalsBase.postYardBase = postSwitch;

                postSwitch.animalsBase = tempAnimals;
                postSwitch.animalsBase.postYardBase = tempPostSwitch;
            
            }
         
       


        }    
        yield return null;
    }
}
