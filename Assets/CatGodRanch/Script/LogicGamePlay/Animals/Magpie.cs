using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Magpie : AnimalsBase
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
    public List<AnimalsBase> lsPlusDailyCoin;
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
    public GameObject dailyCoin;
    public List<GameObject> lsDailyCoin;
    public override void Init()
    {
        SetUpPlus();
        if (lsPlusDailyCoin.Count > 0)
        {
            lsPlusDailyCoin.Clear();
        }    
        Dictionary<AnimalsName, int> animalCount = new Dictionary<AnimalsName, int>();

        // Đếm số lượng mỗi loại AnimalsName
        foreach (var animal in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if (!animalCount.ContainsKey(animal.animalsName))
            {
                animalCount[animal.animalsName] = 0;
            }
            animalCount[animal.animalsName]++;
        }

        // Lọc các đối tượng có số lượng lớn hơn 3
        foreach (var animal in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
        {
            if (animalCount[animal.animalsName] > 3)
            {
                lsPlusDailyCoin.Add(animal);
            }
        }
        if(lsDailyCoin.Count > 0)
        {
            lsDailyCoin.Clear();
        }

    }
    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {
        if (CanHandleEffect)
        {
            if(lsPlusDailyCoin.Count > 0)
            {
                spriteRender.transform.DOKill();
                Sequence sequence = DOTween.Sequence();
                sequence.Append(spriteRender.transform.DOScale(new Vector3(1.4f, 1, 1), 0.15f));
                sequence.Append(spriteRender.transform.DOScale(new Vector3(0.8f, 1, 1), 0.15f));
                sequence.Append(spriteRender.transform.DOScale(new Vector3(1, 1, 1), 0.15f));
                yield return sequence.WaitForCompletion();

                Sequence sequence2 = DOTween.Sequence();
                foreach (var item in lsPlusDailyCoin)
                {
                    var temp = SimplePool2.Spawn(dailyCoin);
                    temp.transform.position = this.transform.position;
                    lsDailyCoin.Add(temp);
                    sequence2.Join(temp.transform.DOJump(item.transform.position, 1.2f,1,0.5f));
                    item.coinPlus += 1;
                }
               
                yield return sequence2.WaitForCompletion();
                foreach (var item in lsDailyCoin)
                {
                    SimplePool2.Despawn(item);
                }
                AnimScale();
                Debug.LogError("Magpie");
            }    

        }
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
  
        yield return null;
    }
}
