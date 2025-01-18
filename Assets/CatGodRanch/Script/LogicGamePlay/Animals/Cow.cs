using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Cow : AnimalsBase
{
    bool isListen = false;
    public List<PostYardBase> lsWasEaten;
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
        if (!isListen)
        {
            EventDispatcher.EventDispatcher.Instance.RegisterListener(EventID.HUNT_SUGGET, HandleEffectAddCalf);
            isListen = true;
        }
        if(lsWasEaten.Count > 0)
        {
            lsWasEaten.Clear();
        }
        foreach (var item in postYardBase.lsNearYard)
        {
            if(item.animalsBase != null)
            {
                if (item.animalsBase.animalsName == AnimalsName.Calf)
                {
                    lsWasEaten.Add(item);
                }
                if (item.animalsBase.animalsName == AnimalsName.WaterBuffalo)
                {
                    lsWasEaten.Add(item);
                }
                if (item.animalsBase.animalsName == AnimalsName.Cow)
                {
                    lsWasEaten.Add(item);
                }
            }
        }
    }

    public override void InitState()
    {
        
    }
    public override IEnumerator HandleClaimCoin()
    {
        yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(coinPlus, transform.position));
 

        yield return null;
    }

    public override void HandleActionDie()
    {
        base.HandleActionDie();
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectAddCalf);
        isListen = false;
    }


    public override IEnumerator HandleEffect()
    {
       
        yield return null;
    }
    public void HandleSpawnCalf(PostYardBase postYardBase)
    {

        var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Calf);
        SpwanAnimals(temp.prefabAnimals, postYardBase);

    }

    public void SpwanAnimals(GameObject animalsBase, PostYardBase postYardBase)
    {

        var tempPost = postYardBase;
        if (tempPost != null)
        {
            if (UseProfile.OnSound)
            {
                audioSource.PlayOneShot(sfx);
            }
            this.transform.DOJump(this.transform.position, 1.5f, 1, 0.2f);
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
        }

    }

    private void HandleEffectAddCalf(object param)
    {
      
        foreach(var item in lsWasEaten)
        {
            if(item.animalsBase == null)
            {
                HandleSpawnCalf(item);
            }
        }

    }
    private void OnDestroy()
    {
        EventDispatcher.EventDispatcher.Instance.RemoveListener(EventID.HUNT_SUGGET, HandleEffectAddCalf);
    }
}
