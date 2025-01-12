using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class TutGamePlay_Step_2 : TutorialBase
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
        Debug.LogError("StartTut");
        if (UseProfile.CurrentLevel == 1)
        {
            StartCoroutine(Show());

        }
    }
    private IEnumerator Show()
    {
        yield return StartCoroutine(GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[0].HandleClaimCoin());
        hand = Instantiate(handTut);
        hand.transform.position = GamePlayController.Instance.playerContain.animalController.lsAnimalsBases[0].transform.position;
        hand.gameObject.GetComponent<HandTutWorkPost>().Init();
    }

    protected override void SetNameTut()
    {

    }
    public override void OnEndTut()
    {

    }
}
