using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class Coyote : AnimalsBase
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
        if(CanHandleEffect)
        {

            int countCarnivore = 0;
            // Đếm số lượng mỗi loại AnimalsName
            foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if(item.animalsType == AnimalsType.Carnivore)
                {
                    countCarnivore += 1;
                }
            }
            if (countCarnivore >= 3)
            {
                boxChat_OK.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                boxChat_OK.gameObject.SetActive(false);
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
            }
            else
            {
                boxChat_NoOk.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                boxChat_NoOk.gameObject.SetActive(false);
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(-2, transform.position));
            }    
         
        }
        yield return null;
    }
}
