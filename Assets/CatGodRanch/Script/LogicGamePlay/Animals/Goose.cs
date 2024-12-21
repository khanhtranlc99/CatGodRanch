using System.Collections;
using System.Collections.Generic;
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
        AnimScale();
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
        Debug.LogError("ProTect");
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
