using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Badger : AnimalsBase
{
    public GameObject boxChat_OK;
    public GameObject boxChat_NoOk;
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
            if (item.animalsBase!= null && item.animalsBase.animalsName ==  AnimalsName.Badger)
            {
                countEmtySpace += 1;
            }
        }
        if (countEmtySpace >= 2)
        {
            boxChat_OK.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            boxChat_OK.gameObject.SetActive(false);
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(4, transform.position));
        }
        else
        {
            boxChat_NoOk.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            boxChat_NoOk.gameObject.SetActive(false);
            yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(-2, transform.position));
        }
        yield return null;
    }
}