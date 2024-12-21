using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : AnimalsBase
{   public bool CheckBirdAround
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
    public AnimalsBase animalsTarget;
    bool huntSuccess;
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
        AnimScale();
        huntSuccess = false;
        animalsTarget = null;
        foreach (var item in postYardBase.lsNearYard)
        {
            if (item.animalsBase != null && item.animalsBase.animalsType == AnimalsType.Bird && item.animalsBase.animalsRank == CardRank.Normal)
            {
                animalsTarget = item.animalsBase;
                break;
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
            if (animalsTarget != null)
            {
                if (animalsTarget.lsAnimalsProtect.Count > 0)
                {
                    huntSuccess = false;
                    yield return transform.DOMove(animalsTarget.gameObject.transform.position, 0.5f).WaitForCompletion();
                    foreach (var item in animalsTarget.lsAnimalsProtect)
                    {
                        yield return StartCoroutine(item.HandleActionProtect());
                    }
                    animalsTarget = null;
                    yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();
                }
                else
                {
                    huntSuccess = true;
                    yield return transform.DOMove(animalsTarget.gameObject.transform.position, 0.5f).WaitForCompletion();
                    animalsTarget.HandleActionDie();
                    animalsTarget = null;
                    yield return transform.DOMove(postYardBase.gameObject.transform.position, 0.5f).WaitForCompletion();
                    var temp = GamePlayController.Instance.playerContain.cardController.GetCardName(AnimalsName.Crow);

                    yield return StartCoroutine(SpwanAnimals(temp.prefabAnimals));

                }
            }
        }
        yield return null;
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
        if (huntSuccess)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.HUNT_SUGGET, this);
        }
    }
    public IEnumerator SpwanAnimals(GameObject animalsBase)
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
            Debug.LogError("SpawnCrow");
        }
        yield return null;
    }
}
