using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : AnimalsBase
{
    public override void Init()
    {
        SetUpPlus();
        if (GamePlayController.Instance.playerContain.itemController.GetItemBase(ItemName.DogTrainningLeash) == null)
        {
            foreach (var item in postYardBase.lsNearYard)
            {
                if (item.animalsBase != null)
                {
                    if (item.animalsBase.animalsName == AnimalsName.Lamp)
                    {
                        item.animalsBase.lsAnimalsProtect.Add(this);
                    }
                    if (item.animalsBase.animalsName == AnimalsName.Goat)
                    {
                        item.animalsBase.lsAnimalsProtect.Add(this);
                    }
                    if (item.animalsBase.animalsName == AnimalsName.Sheep)
                    {
                        item.animalsBase.lsAnimalsProtect.Add(this);
                    }
                    if (item.animalsBase.animalsName == AnimalsName.Alpaca)
                    {
                        item.animalsBase.lsAnimalsProtect.Add(this);
                    }
                }
            }
        }
        else
        {
            foreach (var item in GamePlayController.Instance.playerContain.animalController.lsAnimalsBases)
            {
                if (item != null)
                {
                    if (item.animalsName == AnimalsName.Lamp)
                    {
                        item.lsAnimalsProtect.Add(this);
                    }
                    if (item.animalsName == AnimalsName.Goat)
                    {
                        item.lsAnimalsProtect.Add(this);
                    }
                    if (item.animalsName == AnimalsName.Sheep)
                    {
                        item.lsAnimalsProtect.Add(this);
                    }
                    if (item.animalsName == AnimalsName.Alpaca)
                    {
                        item.lsAnimalsProtect.Add(this);
                    }
                }
            }
        }
     
    }

    public override void InitState()
    {
     
    }

    public override IEnumerator HandleEffect()
    {

        yield return null;
    }

    public override IEnumerator HandleActionProtect()
    {
      Debug.LogError("Protect");
      yield return  StartCoroutine(GamePlayController.Instance.SpawnItemInGameVfx(4, transform.position));
    }

}
