using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutGamePlay_Step_4 : TutorialBase
{
    GameObject hand;
    public Transform post_Canvas;
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
        if (UseProfile.CurrentLevel == 1)
        {
            GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(true);
            var temp = GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.transform.position;
            hand = Instantiate(handTut);
            hand.transform.SetParent(post_Canvas, false);
            hand.transform.localScale = Vector3.one;
            hand.transform.position = new Vector3(temp.x +1 , temp.y + 1.5f , temp.z);
            hand.gameObject.GetComponent<HandTut_Down_UI>().Init();
            

        }
    }

    protected override void SetNameTut()
    {

    }
    public override void OnEndTut()
    {

    }
}