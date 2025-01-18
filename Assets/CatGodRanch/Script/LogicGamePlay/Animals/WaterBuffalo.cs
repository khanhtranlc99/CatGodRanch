using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBuffalo : AnimalsBase
{
  
    public bool NearEater
    {
        get
        {
            foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if (item.animalsBase != null && item.animalsBase.animalsName == AnimalsName.Tiger)
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
            if (NearEater)
            {
                return false;
            }
            else
            {
                return true;
            }
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
        if (CanHandleEffect)
        {
            if (CheckNearYardGrass)
            {
                if (UseProfile.OnSound)
                {
                    audioSource.PlayOneShot(sfx);
                }
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, transform.position));
            }
            if (CheckNearYardPuddle)
            {
                if (UseProfile.OnSound)
                {
                    audioSource.PlayOneShot(sfx);
                }
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(2, transform.position));
            }
        }
        yield return null;
    }
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
    bool CheckNearYardGrass
    {
        get
        {
            foreach (var item in GamePlayController.Instance.playerContain.postYardController.lsPostYardBases)
            {
                if (item.postYardType == PostYardType.Grass)
                {
                    return true;
                }
            }
            return false;
        }
    }
     
}