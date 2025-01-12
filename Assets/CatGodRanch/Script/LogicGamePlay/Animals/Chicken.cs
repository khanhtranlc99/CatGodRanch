using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Chicken : AnimalsBase
{
    public AnimalsBase rooster;
    public GameObject effectSmoke;
    public GameObject boxChat;
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

     
   
    public override void Init()
    {
        SetUpPlus();
        rooster = null;
        foreach (var item in postYardBase.lsNearYard)
        {
           if(item.animalsBase != null && item.animalsBase.animalsName == AnimalsName.Rooster)
            {
                rooster = item.animalsBase;
                break;
            }
        }
    
    }

    public override void InitState()
    {
    
    }

    public override IEnumerator HandleEffect()
    {  
        if(CanHandleEffect  )
        {
            if(rooster != null && rooster.gameObject.activeSelf)
            {
                yield return rooster.gameObject.transform.DOMove(postYardBase.transform.position, 0.5f).WaitForCompletion();
                var tempEffect = SimplePool2.Spawn(effectSmoke, new Vector2(postYardBase.transform.position.x, postYardBase.transform.position.y + 0.5f), Quaternion.identity);
                yield return new WaitForSeconds(1);
                yield return rooster.gameObject.transform.DOMove(rooster.postYardBase.transform.position, 0.5f).WaitForCompletion();
                var ran = Random.RandomRange(0, 100);
                if (!UseProfile.TutGamePlayCard_Step_1)
                {
                    ran = 50;
                }
                if (ran <= 50)
                {
                    yield return this.transform.DOJump(this.transform.position, 1.5f, 1, 0.5f).WaitForCompletion();
                    var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Egg);
                    yield return StartCoroutine(SpwanAnimals(temp.prefabAnimals));
                }
                else
                {
                    boxChat.gameObject.SetActive(true);
                    yield return new WaitForSeconds(1);
                    boxChat.gameObject.SetActive(false);
                }
            }
        }   
         
            if(CheckBirdAround)
            {
              EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
            }
        
        yield return null;
    }
    public IEnumerator SpwanAnimals(GameObject animalsBase)
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
            if(!UseProfile.TutGamePlayCard_Step_1)
            {
                temp.GetComponent<Egg>().day = 1;
                temp.GetComponent<Egg>().Init();
                temp.GetComponent<Egg>().tvDay.text =  "";
                yield return new WaitForSeconds(0.7f);
                yield return temp.GetComponent<AnimalsBase>().HandleEffect();
            }
            
        }
        else
        {
            var temp = SimplePool2.Spawn(animalsBase);
            temp.transform.position = this.transform.position;
            GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
            yield return temp.transform.DOMove(GamePlayController.Instance.playerContain.animalController.postHome.position, 0.5f).WaitForCompletion();
            //temp.transform.position = postYardBase.post.position;
            //postYardBase.animalsBase = temp.GetComponent<AnimalsBase>();
            //temp.GetComponent<AnimalsBase>().postYardBase = postYardBase;
            //GamePlayController.Instance.playerContain.animalController.lsAnimalsBases.Add(temp.GetComponent<AnimalsBase>());
        }
        yield return null;
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
