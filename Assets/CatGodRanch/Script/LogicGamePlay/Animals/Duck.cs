using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : AnimalsBase
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
        foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if (item != null && item.animalsName == AnimalsName.Duck && item != this )
            {
                GamePlayController.Instance.playerContain.animalController.duckController.HandleAddDuck(item);
            }
        }
    }
    public override void InitRange()
    {
        if (lsPostRange.Count > 0)
        {
            lsPostRange.Clear();
        }
        foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
        {
            lsPostRange.Add(item);
        }
    }
    public override void InitState()
    {
     
    }

    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {

            yield return StartCoroutine(GamePlayController.Instance.playerContain.animalController.duckController.HandleEffectDuck());

            if (CheckNearYardPuddle)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, transform.position));
            }
        }
 
        yield return null;
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
    }
    public void ShowVoice()
    {
        if (UseProfile.OnSound)
        {
            audioSource.PlayOneShot(sfx);
        }
    }    

    //bool CheckAllYard 
    //{
    //    get
    //    {
    //        int count = 0;
    //        foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
    //        {
    //            if (item.animalsBase != null && item.animalsBase.animalsName == AnimalsName.Duck)
    //            {
    //                count += 1;
    //            }
    //        }
    //        if(count >= 3)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
    bool CheckNearYardPuddle
    {
        get
        {
            foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if (item.postYardType == PostYardType.Puddle)
                {
                    return true;
                }
            }
            return false;
        }  
    }

}
