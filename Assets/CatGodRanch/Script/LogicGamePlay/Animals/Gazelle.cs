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
    public override void InitRange()
    {
      base.InitRange();
    
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
                if (item.animalsBase != null  )
                {
                    if (CheckCanSwitch(item.animalsBase))
                    {
                        postSwitch = item;
                        break;

                    }
                }
            }
            if(postSwitch != null)
            {
                tempPostSwitch = postYardBase;
                tempAnimals = postYardBase.animalsBase;

                Sequence sequence = DOTween.Sequence();
                sequence.Append(this.transform.DOMove(postSwitch.transform.position, 0.35f));
                sequence.Append(postSwitch.animalsBase.transform.DOMove(postYardBase.transform.position, 0.35f));
                yield return sequence.WaitForCompletion();

                postYardBase = postSwitch;
                postYardBase.animalsBase = postSwitch.animalsBase;
                postYardBase.animalsBase.InitRange();
                postYardBase.animalsBase.SetCurrentInLayer();
                postYardBase.animalsBase.SetOrderInLayer(postYardBase.id);

               
                postSwitch.animalsBase.postYardBase = tempPostSwitch;
                postSwitch.animalsBase = tempAnimals;
                postSwitch.animalsBase.InitRange();
                postSwitch.animalsBase.SetCurrentInLayer();
                postSwitch.animalsBase.SetOrderInLayer(postSwitch.id);


            }
         
       


        }
        Debug.LogError(gameObject.name);
        yield return null;
    }
}
