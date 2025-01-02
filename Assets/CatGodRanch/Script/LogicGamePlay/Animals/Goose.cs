using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Goose : AnimalsBase
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
    public override void Init()
    {
        SetUpPlus();
        foreach (var item in postYardBase.lsNearYard)
        {
            if (item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Bird)
            {
                item.animalsBase.lsAnimalsProtect.Add(this);
            }    
        }    
    }

    public override void InitState()
    {
      
    }
    public override IEnumerator HandleActionProtect()
    {
        yield return this.transform.DOJump(this.transform.position, 1.5f, 1, 0.5f).WaitForCompletion();
        yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, transform.position));
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
