using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuskOx : AnimalsBase
{
    public List<AnimalsBase> lsPlusCoinAnimals;
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
        if (lsPlusCoinAnimals.Count > 0)
        {
            lsPlusCoinAnimals.Clear();
        }
       foreach(var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if(item.animalsType == AnimalsType.Hoofed)
            {
                lsPlusCoinAnimals.Add(item);
            }
        
        }
    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if(CanHandleEffect)
        {
            yield return this.transform.DOJump(this.transform.position, 0.5f, 1, 0.5f).WaitForCompletion();
            foreach (var item in lsPlusCoinAnimals)
            {
                yield return StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(1, item.transform.position));
            }
        }
       
        yield return null;
    }
}