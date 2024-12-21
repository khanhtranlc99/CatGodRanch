using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Badger : AnimalsBase
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
        AnimScale();
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        int countEmtySpace = 0;

        foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
        {
            if (item.animalsBase!= null && item.animalsBase.animalsName ==  AnimalsName.Badger)
            {
                countEmtySpace += 1;
            }
        }
        if (countEmtySpace >= 2)
        {
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(4, transform.position));
        }
        else
        {
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(-2, transform.position));
        }
        yield return null;
    }
}