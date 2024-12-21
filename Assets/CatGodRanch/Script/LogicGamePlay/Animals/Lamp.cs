using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lamp : AnimalsBase
{
    public TMP_Text tvDay;
    int day = 3;

   
    public bool CanHandleEffect
    {
        get
        {
            if(huntAnimal != null && lsAnimalsProtect.Count <= 0)
            {
                return false;
            }    
            return true;
        }
    }
    public override void Init()
    {
        AnimScale();
        tvDay.text = day.ToString() + "<sprite name=\"Time\">";
    }
    public override void InitState()
    {

    }
 
    public override IEnumerator HandleEffect()
    {
        if (CanHandleEffect)
        {
            day -= 1;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            if (day <= 0)
            {
                var ran = Random.RandomRange(0, 100);
                if (ran <= 33)
                {
                    var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Goat);
                    SpwanAnimals(temp.prefabAnimals);
                }
                if (ran > 33 && ran <= 66)
                {
                    var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Alpaca);
                    SpwanAnimals(temp.prefabAnimals);
                }
                if (ran > 66 && ran <= 100)
                {
                    var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Sheep);
                    SpwanAnimals(temp.prefabAnimals);
                }
                EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.GROW_EXPRESS_SUCCEST);
                GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Remove(this);
                SimplePool2.Despawn(this.gameObject);
            }
        }
    
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
        }
    }
}
