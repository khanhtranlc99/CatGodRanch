using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Horse : AnimalsBase
{
  
    public PostYardBase HandleFindRightPost
    {
        get
        {
           

            foreach (var item in postYardBase.lsNearYard)
            {
                if(item.id == postYardBase.id +1 && item.animalsBase == null)
                {
                 
                    return item;
                }
            }
          
            return null;
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
        AnimScale();
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect )
        {
            yield return StartCoroutine(HandleMove());
        }
        yield return null;
    }

    private IEnumerator HandleMove()
    {
        var temp = HandleFindRightPost;
        if (temp != null)
        {
            Debug.LogError("name_" + temp.gameObject.name);
            yield return this.transform.DOMove(temp.transform.position, 0.5f).WaitForCompletion();
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
            postYardBase.animalsBase = null;
            postYardBase = null;
            postYardBase = temp;
            postYardBase.animalsBase = this;
            if (HandleFindRightPost != null)
            {
                yield return StartCoroutine(HandleMove());
            }
            else
            {
                yield return null;
            }
        }
        else
        {
            Debug.LogError("NOOO_"  );
            yield return null;
        }
    }    
}
