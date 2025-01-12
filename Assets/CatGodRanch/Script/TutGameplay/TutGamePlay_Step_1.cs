using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutGamePlay_Step_1 : TutorialBase
{
    public Transform postCanvas;
    public override bool IsCanEndTut()
    {

      return true;
    }

    public override void StartTut()
    {
     
      if(UseProfile.CurrentLevel == 1)
        {
            var temp = Instantiate(handTut);
            temp.transform.SetParent(postCanvas, false);
            temp.GetComponent<NoticeController>().Init();
            GamePlayController.Instance.gameScene.HandleOffButton();
        }
    }

    protected override void SetNameTut()
    {
       
    }
 
    public override void OnEndTut()
    {

    }
}
