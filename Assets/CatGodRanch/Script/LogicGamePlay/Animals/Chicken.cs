using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chicken : AnimalsBase
{
    public bool CheckBirdAround
    {
        get 
        { 
            foreach(var item in postYardBase.lsNearYard)
            {
                if(item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Bird)
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

    public TMP_Text tvDay;
    int day = 3;
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
        if(CanHandleEffect)
        {
            day -= 1;
            tvDay.text = day.ToString() + "<sprite name=\"Time\">";
            if (day <= 0)
            {
                var ran = Random.RandomRange(0, 100);
                if (ran <= 50)
                {
                    day = 3;
                    tvDay.text = day.ToString() + "<sprite name=\"Time\">";
                }
                else
                {
                    var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Egg);
                    SpwanAnimals(temp.prefabAnimals);
                }
            }
        }   
         
            if(CheckBirdAround)
            {
              EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
            }
        
        yield return null;
    }
    public void SpwanAnimals(GameObject animalsBase)
    {

        var tempPost = GetEmptyPost;
        if (tempPost != null)
        {
            //postYardBase.animalsBase = null;
            //postYardBase = null;
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = tempPost.post.position;
            tempPost.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = tempPost;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
     
            
        }
        else
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = postYardBase.post.position;
            postYardBase.animalsBase = temp.GetComponent<AnimalsBase>();
            temp.GetComponent<AnimalsBase>().postYardBase = postYardBase;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
        }    

    }

    PostYardBase GetEmptyPost
    {
        get
        {
            foreach(var item in postYardBase.lsNearYard)
            {
                if(item.animalsBase == null)
                {
                    return item;
                }    
            }
            return null;
        }
    }
    

}
