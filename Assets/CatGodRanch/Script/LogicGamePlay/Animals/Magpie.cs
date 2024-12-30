using System.Collections;
using System.Collections.Generic;
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
                foreach(var item in lsAnimalsProtect)
                {
                    item.coinPlus += 1;
                    Debug.LogError("Magpie_" + item.animalsName);
                }
                Debug.LogError("HandleEffect_Magpie");
            }    

        }
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
        yield return null;
    }
}
