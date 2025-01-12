using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rooster : AnimalsBase
{
    public GameObject boxChat;
    public bool nearRooster
    {
        get
        {
            foreach(var item in postYardBase.lsNearYard)
            {
                if(item.animalsBase != null && item.animalsBase.animalsName == AnimalsName.Rooster)
                {
                    return true;
                }
            }
            return false;
        }
    } 
        
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
        if(!UseProfile.TutGamePlayCard_Step_1)
        {
            GamePlayController.Instance.tutCard.StartTut();
        }
  
    }

    public override void InitState()
    {

    }
    public override IEnumerator HandleEffect()
    {   
        yield return null;
        if (CheckBirdAround)
        {
            EventDispatcher.EventDispatcher.Instance.PostEvent(EventID.TRIBAL_TALENT, this.gameObject);
        }
    }

    public override IEnumerator HandleClaimCoin()
    {
        if(nearRooster)
        {
            boxChat.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            boxChat.gameObject.SetActive(false);
        }
        else
        {
            yield return base.HandleClaimCoin();
        }
    
    }

}