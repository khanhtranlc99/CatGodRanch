using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutGamePlay_Step_3 : TutorialBase
{
    GameObject hand;
    public Transform post_Btn;

    public override bool IsCanEndTut()
    {
        if (hand != null)
        {
            UseProfile.TutGamePlay_Step_3 = true;
            Destroy(hand.gameObject);
        }
        return true;
    }

    public override void StartTut()
    {
        
        if (UseProfile.CurrentLevel == 1)
        {
            hand = Instantiate(handTut);
            hand.transform.position = post_Btn.position;
            hand.gameObject.GetComponent<HandTutWorkPost>().Init();
            
        }
    }

    protected override void SetNameTut()
    {

    }
    public override void OnEndTut()
    {

    }
}