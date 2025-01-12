using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutGamePlayCard_Step_1_5 : TutorialBase
{
    public static TutGamePlayCard_Step_1_5 Instance;
    public Transform post_Canvas;
    GameObject hand;
   

    public override bool IsCanEndTut()
    {
       
        return true;
    }

    private void Start()
    {
        Instance = this;
    }

    public override void StartTut()
    {
        
        Debug.LogError(gameObject.name);
        GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.SetActive(true);
      

    }
    public void HandleShowHand()
    {
        var temp = GamePlayController.Instance.playerContain.animalController.btnNextDay.gameObject.transform.position;
        hand = Instantiate(handTut);
        hand.transform.SetParent(post_Canvas, false);
        hand.transform.localScale = Vector3.one;
        hand.transform.position = new Vector3(temp.x + 1, temp.y + 1.5f, temp.z);
        hand.gameObject.GetComponent<HandTut_Down_UI>().Init();
    }    
    public void HandleOffHand()
    {
        if (hand != null)
        {
            Destroy(hand.gameObject);
        }
    }

   

    protected override void SetNameTut()
    {

    }
    public override void OnEndTut()
    {

    }
}
