using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turkey : AnimalsBase
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
    public override void InitRange()
    {

    }
    public override void InitState()
    { 
    }
       

    public override void HandleActionDie()
    {
        if (UseProfile.OnSound)
        {
            audioSource.PlayOneShot(sfx);
        }
        StartCoroutine(  GamePlayController.Instance.SpawnItemInGameVfx(5, transform.position));
      base.HandleActionDie() ;
     
    }

 
 
  

    public override IEnumerator HandleEffect()
    {
 
        yield return null;
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
    }


}

