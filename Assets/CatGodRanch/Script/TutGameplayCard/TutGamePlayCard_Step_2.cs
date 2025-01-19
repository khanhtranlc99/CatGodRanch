using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutGamePlayCard_Step_2 : TutorialBase
{
    GameObject hand;
    public override bool IsCanEndTut()
    {
        if (hand != null)
        {
            Destroy(hand.gameObject);
        }
        return true;
    }

    public override void StartTut()
    {
        Debug.LogError(gameObject.name);
        StartCoroutine(Show());

        
    }
    public IEnumerator Show()
    {
        //yield return StartCoroutine(GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[2].HandleClaimCoin());
        hand = Instantiate(handTut);
        hand.transform.position = GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[2].transform.position;
        hand.gameObject.GetComponent<HandTutWorkPost>().Init();
        GamePlayController.Instance.playerContain.inputController.lockInput = true;
        yield return null;
    }
    protected override void SetNameTut()
    {

    }
    public override void OnEndTut()
    {

    }
}