using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TutGamePlayCard_Step_1 : TutorialBase
{
    public static TutGamePlayCard_Step_1 Instance;
    GameObject hand;
    public GameObject hand1;
    public override bool IsCanEndTut()
    {
        if (hand != null)
        {
            Destroy(hand.gameObject);
        }
        return true;
    }

    private void Start()
    {
        Instance = this;
    }
    public override void StartTut()
    {
      
        controller.isStart = true;
    }

    public IEnumerator Show(Transform param)
    {
        yield return new WaitForEndOfFrame();
        hand = Instantiate(handTut);
        hand.transform.SetParent(param, false);
        hand.transform.position = new Vector3(param.position.x -1.5f, param.position.y -4, param.position.z);
        hand.gameObject.GetComponent<HandTut_Down_UI>().Init();
     
    }
    public IEnumerator Show2(Transform param)
    {
        yield return new WaitForEndOfFrame();
        hand = Instantiate(hand1);
        hand.transform.SetParent(param, false);
        hand.transform.position = new Vector3(param.position.x +1.5f, param.position.y-2.5f, param.position.z);
        hand.gameObject.GetComponent<HandTut_Down_UI>().Init();

    }
    public void HandleOffHandle()
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
