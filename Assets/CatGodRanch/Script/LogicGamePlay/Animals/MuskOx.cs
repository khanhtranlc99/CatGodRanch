using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuskOx : AnimalsBase
{
    public List<AnimalsBase> lsPlusCoinAnimals;
    public List<GameObject> lsDailyCoin;
    public GameObject dailyCoin;
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
        if (CanHandleEffect)
        {
            if (lsPlusCoinAnimals.Count > 0)
            {
                spriteRender.transform.DOKill();
                Sequence sequence = DOTween.Sequence();
                sequence.Append(spriteRender.transform.DOScale(new Vector3(1.4f, 1, 1), 0.15f));
                sequence.Append(spriteRender.transform.DOScale(new Vector3(0.8f, 1, 1), 0.15f));
                sequence.Append(spriteRender.transform.DOScale(new Vector3(1, 1, 1), 0.15f));
                yield return sequence.WaitForCompletion();

                Sequence sequence2 = DOTween.Sequence();
                foreach (var item in lsPlusCoinAnimals)
                {
                    var temp = SimplePool2.Spawn(dailyCoin);
                    temp.transform.position = this.transform.position;
                    lsDailyCoin.Add(temp);
                    sequence2.Join(temp.transform.DOJump(item.transform.position, 1.2f, 1, 0.5f));
                    item.coinPlus += 1;
                }

                yield return sequence2.WaitForCompletion();
                foreach (var item in lsDailyCoin)
                {
                    SimplePool2.Despawn(item);
                }
                AnimScale();
         
            }

        }
     

        yield return null;
    }
}