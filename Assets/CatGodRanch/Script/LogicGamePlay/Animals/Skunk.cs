using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skunk : AnimalsBase
{
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
    public override IEnumerator HandleEffect()
    {
        int countEmtySpace = 0;
      
        foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
        {
            if (item.animalsBase == null)
            {
                countEmtySpace += 1;
            }
        }
        if (countEmtySpace >= 1)
        {
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
        }
        else
        {
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(-1, transform.position));
        }
        yield return null;
    }
}
