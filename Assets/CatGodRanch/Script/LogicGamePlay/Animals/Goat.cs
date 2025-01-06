using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goat : AnimalsBase
{
   
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
    public override void InitRange()
    {
        
    }

    public override void InitState()
    {
      
    }

    public override void HandleActionDie()
    {
        EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.GOAT_HORN);
        var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Lamp);
        SpwanAnimals(temp.prefabAnimals);

      
   
    }

   

   
    public override IEnumerator HandleEffect()
    {
        yield return null;
    }

    public void SpwanAnimals(GameObject animalsBase)
    {

        var tempPost = postYardBase;
        if (tempPost != null)
        {
            postYardBase.animalsBase = null;
            postYardBase = null;
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
            SimplePool2.Despawn(this.gameObject);
            Debug.LogError("GoatDie");
        }

    }
}
